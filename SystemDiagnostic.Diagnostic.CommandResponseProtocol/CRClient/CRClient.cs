using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Exceptions;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.TCPProtocol.Client;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient
{
    internal class CRClient : ICRClient
    {
        public int ResponseWaitMS { get; set; } = 5000;
        public int MaxResendCount { get; set; } = 3;
        public int CheckCommandUpdateMS {get;set;} = 1000;
        private ITCPClient _TCPClient;
        private object commandQueueLocker = new object();
        private Thread _checkResponseThread;
        private IList<SendCommandInformation> _sendCommands;
        private IClientMediator _clientMediator;


        public CRClient(IClientMediator clientMediator)
        {
            _clientMediator = clientMediator;
            _sendCommands = new List<SendCommandInformation>();
            _checkResponseThread = new Thread(CheckCommandQueue);
            _checkResponseThread.Start();
        }

        public void Run(IPAddress address, int port)
        {
            try{
                _TCPClient = new TCPClient(address, port);
                _TCPClient.Connect();
                _TCPClient.RecieveDataEvent += RecieveResponse;
            }catch(SocketException){
                _TCPClient.Dispose();
                throw new CRClientException("Cant connect to server with this ip:" + address.ToString());
            }
        }

        public void RecieveUserCommand(ClientCommandDTO newClientCommand)
        {
            SendCommand(newClientCommand);
            InitializeSendCommand(newClientCommand);
        }

        private void InitializeSendCommand(ClientCommandDTO clientCommand)
        {
            lock (commandQueueLocker)
            {
                _sendCommands.Add(new SendCommandInformation(clientCommand));
            }
        }

        private void RecieveResponse(byte[] data, IPEndPoint sender)
        {
            string responseSerialization = Encoding.ASCII.GetString(data);
            ServerResponseDTO serverResponse = JsonConvert
                .DeserializeObject<ServerResponseDTO>(responseSerialization);
            RemoveSendCommandByResponse(serverResponse);
            _clientMediator.HandleResponse(serverResponse);
        }

        private void SendCommand(ClientCommandDTO clientCommand)
        {
            string commandSerialization = JsonConvert.SerializeObject(clientCommand);
            byte[] commandByteArray = Encoding.ASCII.GetBytes(commandSerialization);
            _TCPClient.SendDataAsync(commandByteArray);
        }

        private void RemoveSendCommandByResponse(ServerResponseDTO serverResponse)
        {
            lock (commandQueueLocker)
            {
                SendCommandInformation sendCommand = _sendCommands
                    .Where(c => c.Command.IdCommand.Equals(serverResponse.IdCommand)).FirstOrDefault();
                if (sendCommand != null)
                    _sendCommands.Remove(sendCommand);
            }
        }

        private void CheckCommandQueue()
        {
            while (true)
            {
                lock (commandQueueLocker)
                {
                    foreach (SendCommandInformation command in _sendCommands)
                    {
                        if ((DateTime.Now - command.SendTime).Milliseconds>= ResponseWaitMS)
                        {
                            command.CountResend++;
                            SendCommand(command.Command);
                        }
                        if (command.CountResend >= MaxResendCount){
                            //TODO : Quit or logging this idk
                            _sendCommands.Remove(command);
                            break;
                        }
                    }
                }
                Thread.Sleep(CheckCommandUpdateMS);
            }
        }

        public void Dispose()
        {
            _TCPClient.Dispose();
        }
    }
}
