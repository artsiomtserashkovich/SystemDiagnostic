using System;
using System.Net;
using System.Collections;
using SystemDiagnostic.Diagnostic.TCPProtocol.Client;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.Client.NetworkClient.Handlers;
using SystemDiagnostic.Diagnostic.DTO.CommandHandlerEntities;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.DTO.NetworkEntities;
using Newtonsoft.Json;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient
{
    public class NetworkClient : IDisposable
    {
        private ITCPClient TCPClient { get; set; }
        private CommandsHandler CommandsHandler { get; set; }
        public NetworkClient(IPAddress iPAddress, int port)
        {
            TCPClient = new TCPClient(iPAddress, port);
            TCPClient.RecieveDataEvent += GetServerData;
            TCPClient.Connected += Connected;
            TCPClient.ConnectionShutdown += ConnectionLost;
        }

        public void Connect()
        {
            TCPClient.Connect();
        }

        public void SendClientCommand(ClientCommand clientCommand){
            string clientCommandSerialization 
                =JsonConvert.SerializeObject(clientCommand);
            ClientDTO clientDTO = new ClientDTO{
                Type = TransferConstant.Command,
                Data = clientCommandSerialization
            };
            SendClientData(clientDTO);
        }

        private void SendClientResponse(ClientResponse clientResponse){
            string clientResponseSerialization 
                = JsonConvert.SerializeObject(clientResponse);
            ClientDTO clientDTO = new ClientDTO{
                Type = TransferConstant.Response,
                Data = clientResponseSerialization
            };
            SendClientData(clientDTO);
        }

        private void SendClientData(ClientDTO data)
        {
            string dataSeialization = JsonConvert.SerializeObject(data);
            byte[] dataByteArray = Encoding.ASCII.GetBytes(dataSeialization);
            TCPClient.SendDataAsync(dataByteArray);
        }


        private void GetServerData(byte[] message, IPEndPoint address)
        {
            try
            {
                string dataSerialization = Encoding.ASCII.GetString(message);
                ServerDTO serverDTO = JsonConvert.DeserializeObject<ServerDTO>(dataSerialization);

                Console.WriteLine(serverDTO.Type);
                Console.WriteLine(serverDTO.Data);

                if(serverDTO.Type.Equals(TransferConstant.Command)){
                    ServerCommand serverCommand 
                        = JsonConvert.DeserializeObject<ServerCommand>(serverDTO.Data);
                    ClientResponse clientResponse 
                        = CommandsHandler.RecieveCommand(serverCommand);
                    SendClientResponse(clientResponse);
                }
                else if(serverDTO.Type.Equals(TransferConstant.Response)){
                    ServerResponse serverResponse 
                        = JsonConvert.DeserializeObject<ServerResponse>(serverDTO.Data);
                    CommandsHandler.RecieveResponse(serverResponse);
                }
                else throw new Exception("Undefined type of data");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Connected(IPEndPoint ipaddress)
        {
            Console.WriteLine("You connected");
        }

        private void ConnectionLost(IPEndPoint ipaddress)
        {
            Console.WriteLine("You Disconnected");
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            TCPClient.Dispose();
        }
    }
}
