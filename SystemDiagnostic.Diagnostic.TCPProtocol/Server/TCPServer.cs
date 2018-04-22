using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using SystemDiagnostic.Diagnostic.TCPProtocol.Extensions;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Server
{
    public class TCPServer : IServer
    {
        public IEnumerable<IPEndPoint> Clients
        {
            get
            {
                return clients.Select(c => c.Key).ToList();
            }
        }
        public int SendBufferLength { get; set; } = Constans.SendBufferSize;
        public int RecieveBufferLength { get; set; } = Constans.RecieveBufferSize;
        public int TimeOutPing { get; set; } = Constans.TimeOutPing;
        public int MaxBacklogConnection {get;private set;} = Constans.MaxBackLogConnections;

        private IPEndPoint ServerEndPoint { get; }
        private Socket Socket { get; }
        private IDictionary<string, IPEndPoint> clientsId;
        private IDictionary<IPEndPoint, Socket> clients;        


        public event RecieveDataSocket RecieveDataEvent;
        public event SocketAction SystemCloseEvent;

        public Task BroadCastData(byte[] data)
        {
            List<Task> sendTasks = clients.Select(client =>SendData(data,client.Key)).ToList();
            return Task.WhenAll(sendTasks);
        }

        public bool Kick(IPEndPoint client)
        {
            throw new NotImplementedException();
        }

        public Task SendData(byte[] data, IPEndPoint recipient)
        {
            throw new NotImplementedException();
        }

        public void Start(int maxBacklogConnection)
        {
            Socket.Bind(ServerEndPoint);
            Thread startListeningThread = new Thread(StartListening); 
            startListeningThread.Start();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }

        private async void StartListening()
        {
            Socket.Listen(MaxBacklogConnection);
            while (true)
            {
                Socket newClient = await Socket.AcceptAsync().ConfigureAwait(false); 

            }
        }

        
    }
}
