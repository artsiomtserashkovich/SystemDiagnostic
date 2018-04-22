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
            get { return clients.Keys; }
        }
        public int SendBufferLength { get; set; } = Constans.SendBufferSize;
        public int RecieveBufferLength { get; set; } = Constans.RecieveBufferSize;
        public int TimeOutPing { get; set; } = Constans.TimeOutPing;
        public int MaxBacklogConnection { get; private set; }

        private IPEndPoint ServerIPEndPoint { get; }
        private Socket Socket { get; }
        private IDictionary<IPEndPoint, Socket> clients;


        public event RecieveDataSocket RecieveDataEvent;
        public event SocketAction ClientConnected;
        public event SocketAction ClientDisconnected;

        public TCPServer(IPAddress iPAddress, int port)
        {
            clients = new Dictionary<IPEndPoint, Socket>();
            ServerIPEndPoint = new IPEndPoint(iPAddress, port);
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        #region Public Methods
        public Task BroadCastData(byte[] data)
        {
            List<Task> sendTasks = clients.Select(client => SendDataAsync(data, client.Key)).ToList();
            return Task.WhenAll(sendTasks);
        }

        public bool Kick(IPEndPoint client)
        {
            return DisconnectClient(client);
        }

        public async Task SendDataAsync(byte[] data, IPEndPoint recipient)
        {
            Socket recipientSocket;
            if (!clients.TryGetValue(recipient, out recipientSocket) || data == null)
                throw new TCPProtocolException("Bad sending value.");
            try
            {
                await TCPSegmentSizeFormater.SendTCPSegmentSize(recipientSocket, data.Length).ConfigureAwait(false);
                ArraySegment<byte> dataSegment = new ArraySegment<byte>(data);
                int sendData = 0;
                while (sendData < data.Length)
                {
                    int bufferSize = data.Length - sendData;
                    if (bufferSize > SendBufferLength)
                        bufferSize = SendBufferLength;
                    ArraySegment<byte> sliceData = dataSegment.SliceEx(sendData, bufferSize);
                    sendData = await Socket.SendAsync(sliceData, SocketFlags.None).ConfigureAwait(false);

                }
                if (sendData < 1)
                    throw new TCPProtocolException("");
            }
            catch (SocketException exce)
            {
                throw new TCPProtocolException("", exce);
            }
            catch (TransferException excep)
            {
                throw new TCPProtocolException("", excep);
            }
        }

        public void Start(int maxBacklogConnection = Constans.MaxBackLogConnections)
        {
            MaxBacklogConnection = maxBacklogConnection;
            Socket.Bind(ServerIPEndPoint);
            Thread startListeningThread = new Thread(StartListening);
            startListeningThread.Start();
        }

        public void Stop()
        {
            foreach (IPEndPoint client in clients.Keys)
                DisconnectClient(client);
        }
        #endregion

        #region Private Methods
        private void StartListening()
        {
            Socket.Listen(MaxBacklogConnection);
            while (true)
            {
                Task<Socket> newClient = Socket.AcceptAsync();
                new Thread(() => AcceptClientAsync(newClient)).Start();
            }
        }

        private async void AcceptClientAsync(Task<Socket> clientSocket)
        {
            Socket socket = await clientSocket.ConfigureAwait(false);
            IPEndPoint endPoint = socket.RemoteEndPoint as IPEndPoint;
            clients.Add(endPoint, socket);
            StartReceivingAsync(socket);
            KeepAliveAsync(socket);
            ClientConnected?.Invoke(endPoint);
        }

        private async void StartReceivingAsync(Socket clientSocket)
        {
            IPEndPoint iPEndPoint = clientSocket.RemoteEndPoint as IPEndPoint;
            while (true)
            {
                try
                {
                    int dataSize = await TCPSegmentSizeFormater.ReceiveTCPSegmentSize(clientSocket);
                    byte[] data = new byte[dataSize];
                    ArraySegment<byte> dataSegment = new ArraySegment<byte>();
                    int recieveSize = 0;
                    while (recieveSize < dataSize)
                    {
                        int bufferSize = dataSize - recieveSize;
                        if (bufferSize > RecieveBufferLength)
                            bufferSize = RecieveBufferLength;
                        ArraySegment<byte> partData = dataSegment.SliceEx(recieveSize, bufferSize);
                        recieveSize += await Socket.ReceiveAsync(partData, SocketFlags.None).ConfigureAwait(false);
                    }
                    if (recieveSize < 1)
                        throw new TCPProtocolException("Receive transfer data was damaged.");
                    RecieveDataEvent?.Invoke(dataSegment.Array, iPEndPoint);
                }
                catch (SocketException excep)
                {
                    bool success = DisconnectClient(iPEndPoint);
                    if (success)
                        throw new TCPProtocolException("", excep);
                }
                catch (TransferException except)
                {
                    bool success = DisconnectClient(iPEndPoint);
                    if (success)
                        throw new TCPProtocolException("", except);
                }
            }
        }

        private bool DisconnectClient(IPEndPoint iPEndPoint)
        {
            Socket recipientSocket;
            if (!clients.TryGetValue(iPEndPoint, out recipientSocket))
                throw new TCPProtocolException("Dont have socket.");
            try
            {
                recipientSocket.Disconnect(false);
                recipientSocket.Close();
                recipientSocket.Dispose();
                clients.Remove(iPEndPoint);
                ClientDisconnected?.Invoke(iPEndPoint);
            }
            catch
            {
                return !recipientSocket.Ping();
            }
            return true;
        }

       
        private async void KeepAliveAsync(Socket clientSocket)
        {
            while (true)
            {
                await Task.Delay(TimeOutPing).ConfigureAwait(false);
                bool isAlive = clientSocket.Ping();
                if (isAlive) continue;
                DisconnectClient(clientSocket.RemoteEndPoint as IPEndPoint);
                continue;
            }
        }
        #endregion        

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Stop();
                    Socket?.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
