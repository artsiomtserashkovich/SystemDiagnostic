using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.TCPProtocol.Client;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient
{
    internal class CRClient : ICRClient
    {
        public int ResponseWaitMS { get; set; } = 500;
        public int MaxResendCount { get; set; } = 3;
        public int CheckCommandUpdateMS {get;set;} = 100;
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
        }

        public void Run(IPAddress address, int port)
        {
            _TCPClient = new TCPClient(address, port);
            _TCPClient.Connect();
            _TCPClient.RecieveDataEvent += RecieveResponse;
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
            if (_sendCommands.Count == 1 && !_checkResponseThread.IsAlive)
                _checkResponseThread.Start();
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
                    if (_sendCommands.Count == 0)
                        return;
                    foreach (SendCommandInformation command in _sendCommands)
                    {
                        if ((command.SendTime - DateTime.Now).Milliseconds >= ResponseWaitMS)
                        {
                            command.CountResend++;
                            SendCommand(command.Command);
                        }
                        if (command.CountResend >= MaxResendCount)
                            //TODO : Quit or logging this idk
                            _sendCommands.Remove(command);
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
