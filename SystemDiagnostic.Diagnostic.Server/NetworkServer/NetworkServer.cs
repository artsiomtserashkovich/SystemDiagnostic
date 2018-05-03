using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using SystemDiagnostic.Diagnostic.DTO.CommandHandlerEntities;
using SystemDiagnostic.Diagnostic.DTO.NetworkEntities;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;
using SystemDiagnostic.Diagnostic.TCPProtocol.Server;

namespace SystemDiagnostic.Diagnostic.Server.NetworkServer
{
    public class NetworkServer
    {
        private ITCPServer TCPServer {get;set;}
        IDictionary <IPEndPoint,ClientInformation> clients;
        private CommandHandler CommandHandler {get;set;}

        public NetworkServer(IPAddress iPAddress,int port){
            TCPServer = new TCPServer(iPAddress,port);
            TCPServer.ClientConnected += ConnectedUser;
            TCPServer.RecieveDataEvent += RecieveData;
        }

        private void RecieveData(byte[] data, IPEndPoint sender){
            string dataSerialization = Encoding.ASCII.GetString(data);
            ServerDTO serverDTO = JsonConvert.DeserializeObject<ServerDTO>(dataSerialization);
            if(serverDTO.Type.Equals(TransferConstant.Command)){
                ClientCommand clientCommand 
                    = JsonConvert.DeserializeObject<ClientCommand>(serverDTO.Data);
                ClientInformation clientInformation;
                clients.TryGetValue(sender,out clientInformation);
                ServerResponse serverResponse = CommandHandler.RecieveClientCommand(clientInformation,clientCommand);
                SendServerResponse(serverResponse);
            }  
        }

        public void SendServerCommand(ClientInformation clientInformation,ServerCommand serverCommand){
            KeyValuePair<IPEndPoint,ClientInformation> clientPair;
            if(clientPair)
                throw new Exception("Dont have client with this properties.");
            ServerDTO serverDTO = new ServerDTO{
                Type = TransferConstant.Command,
                Data = JsonConvert.SerializeObject(serverCommand)
            };
            SendServerData(serverDTO);
        }

        private void SendServerData(ServerDTO serverDTO)
        {
            throw new NotImplementedException();
        }

        private void SendServerResponse(ServerResponse serverResponse)
        {
            throw new NotImplementedException();
        }

        private void ConnectedUser(IPEndPoint iP){
            clients.Add(iP,new ClientInformation());
        }

    }
}
