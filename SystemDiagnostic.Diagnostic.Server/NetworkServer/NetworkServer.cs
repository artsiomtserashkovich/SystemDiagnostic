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

        public NetworkServer(IPAddress iPAddress,int port,IServiceProvider service){
            TCPServer = new TCPServer(iPAddress,port);
            TCPServer.ClientConnected += ConnectedUser;
            TCPServer.RecieveDataEvent += RecieveData;
            TCPServer.ClientDisconnected += DisconnectedUser;
            clients = new Dictionary<IPEndPoint,ClientInformation>();
            CommandHandler = new CommandHandler(service);
        }

        public void Start(int MaxUsers){
            TCPServer.Start(MaxUsers);
        }

        private void DisconnectedUser(IPEndPoint iPEndPoint)
        {
            if(!clients.Remove(iPEndPoint))
                throw new Exception("Error at network protocol(Uninitial user).");
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
                SendServerResponse(serverResponse,clientInformation);
            }  
        }

        public void SendServerCommand(ServerCommand serverCommand,ClientInformation clientInformation){            
            ServerDTO serverDTO = new ServerDTO{
                Type = TransferConstant.Command,
                Data = JsonConvert.SerializeObject(serverCommand)
            };
            SendServerData(serverDTO,clientInformation);
        }

        private void SendServerData(ServerDTO serverDTO,ClientInformation clientInformation)
        {
            if(!clients.Keys.Contains(clientInformation.IpAddress))
                throw new Exception($"Dont have client with this IpEndPoint{clientInformation.IpAddress.ToString()}.");
            string serverDTOSerializatin = JsonConvert.SerializeObject(serverDTO);
            byte[] serverDTOByteArray = Encoding.ASCII.GetBytes(serverDTOSerializatin);
            TCPServer.SendDataAsync(serverDTOByteArray,clientInformation.IpAddress);
        }

        private void SendServerResponse(ServerResponse serverResponse,ClientInformation clientInformation)
        {
            ServerDTO serverDTO = new ServerDTO{
                Type = TransferConstant.Response,
                Data = JsonConvert.SerializeObject(serverResponse)
            };
            SendServerData(serverDTO,clientInformation);
        }

        private void ConnectedUser(IPEndPoint ipAddress){
            clients.Add(ipAddress,new ClientInformation(ipAddress));
        }

    }
}
