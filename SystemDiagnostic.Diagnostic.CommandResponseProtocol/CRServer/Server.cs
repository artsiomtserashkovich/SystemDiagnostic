using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.TCPProtocol.Server;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer
{
    public class Server : IServer
    {
        
        private ITCPServer _tcpServer;
        private IServerCommandHandler _serverCommandHandler;
        
        public Server(IServerCommandHandler serverCommandHandler){
            _serverCommandHandler = serverCommandHandler;
        }

        public void Run(IPAddress iPAddress, int port,int countClients)
        {
            _tcpServer = new TCPServer(iPAddress,port);
            _tcpServer.RecieveDataEvent += RecieveClientCommand;
            _tcpServer.Start(countClients);
        }

        public void BroadcastResponse(ServerResponseDTO serverResponse){
            string responseSerialization = JsonConvert.SerializeObject(serverResponse);
            byte[] responseBytesArray = Encoding.ASCII.GetBytes(responseSerialization);
            _tcpServer.BroadCastData(responseBytesArray);
        }

        private void RecieveClientCommand(byte[] message, IPEndPoint sender){
            string clientCommandSerialization = Encoding.ASCII.GetString(message);
            ClientCommandDTO clientCommand 
                = JsonConvert.DeserializeObject<ClientCommandDTO>(clientCommandSerialization);
            ServerResponseDTO serverResponse = _serverCommandHandler.HandleCommand(clientCommand);
            string serverResponseSerialization = JsonConvert.SerializeObject(serverResponse);
            byte[] serverResponseBytesArray = Encoding.ASCII.GetBytes(serverResponseSerialization);
            _tcpServer.SendDataAsync(serverResponseBytesArray,sender); 
        }
    }
}
