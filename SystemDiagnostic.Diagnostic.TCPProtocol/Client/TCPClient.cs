using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using SystemDiagnostic.Diagnostic.TCPProtocol.Extensions;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Client
{
    public class TCPClient : ITCPClient
    {

        private Socket serverSocket;
        private IPEndPoint serverIPEndPoint;
        public bool isConnected { get; private set; }
        private bool isReconnecting { get; set; }
        public event RecieveDataSocket RecieveDataEvent;
        public event SocketAction ConnectionShutdown;
        public event SocketAction Connected;

        public bool AutoReconnect { get; set; }
        public int SendBufferLength { get; set; }
        public int RecieveBufferLength { get; set; }
        public int TimeOutPing { get; set; }
        public int ReconnectTime { get; set; }

        public TCPClient(IPAddress address, int port)
        {
            serverIPEndPoint = new IPEndPoint(address, port);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }
        public async Task SendDataAsync(byte[] data)
        {
            if(isConnected == false)
                throw new TCPProtocolException("Dont Connected to server.");
            if(data == null)
                throw new TCPProtocolException("Bad sending value");            
            try{
                ArraySegment<byte> dataSegment = new ArraySegment<byte>(data);
                await TCPSegmentSizeFormater.SendTCPSegmentSize(serverSocket,data.Length);
                int send = 0;
                while(send < data.Length){
                    int lost = data.Length - send;
                    if(lost > SendBufferLength)
                        lost = SendBufferLength;
                    ArraySegment<byte> tempBuffer = dataSegment.SliceEx(send,lost);
                    send += await serverSocket.SendAsync(tempBuffer,SocketFlags.None);
                }
                if(send < 1)
                    throw new TCPProtocolException("${send} bytes send.Connection shutdown");
            }catch(SocketException exc){
                throw new TCPProtocolException("Connection error.",exc);
            }
            catch(TransferException excep){
                throw new TCPProtocolException("Trasfer error.",excep);
            }            
        }

        public void Disconnect()
        {
            try
            {
                serverSocket?.Disconnect(false);
                isConnected = false;
                isReconnecting = false;
                serverSocket?.Close();
                serverSocket?.Dispose();
            }
            catch (ObjectDisposedException) { }
        }

        public void Connect()
        {
            if (isConnected == true)
                throw new TCPProtocolException("Already connected.");
            try
            {
                new Thread(StartListeningAsync).Start();
                new Thread(PingAsync).Start();
                isConnected = true;
            }
            catch (SocketException exce)
            {
                throw new TCPProtocolException("", exce);
            }
        }

        private async Task Reconnect()
        {
            if (isReconnecting) return;
            isReconnecting = true;
            isConnected = false;
            while (true)
            {
                try
                {
                    serverSocket.Disconnect(true);
                    await serverSocket.ConnectAsync(serverIPEndPoint).ConfigureAwait(false);
                    isReconnecting = false;
                    isConnected = true;
                    return;
                }
                catch (SocketException)
                {  }
                await Task.Delay(ReconnectTime).ConfigureAwait(false);
            }
        }

        private async void PingAsync()
        {
            while (true)
            {
                await Task.Delay(TimeOutPing).ConfigureAwait(false);
                bool isAlive = serverSocket.Ping();
                if (isAlive) continue;
                ConnectionShutdown?.Invoke(serverIPEndPoint);
                if (AutoReconnect)
                    await Reconnect().ConfigureAwait(false);
                else
                    Disconnect();
                continue;
            }
        }

        private async void StartListeningAsync()
        {
            Connected?.Invoke(serverIPEndPoint);
            while(true){
                try{
                    int dataSize = await TCPSegmentSizeFormater.ReceiveTCPSegmentSize(serverSocket);
                    byte[] data =new byte[dataSize];
                    ArraySegment<byte> dataSegment= new ArraySegment<byte>(data);
                    int recievedData =0;
                    while(recievedData < dataSize){
                        int lost = dataSize - recievedData;
                        if(lost > RecieveBufferLength )
                            lost = RecieveBufferLength;
                        ArraySegment<byte> tempSegment = dataSegment.SliceEx(recievedData,lost);
                        recievedData += await serverSocket.ReceiveAsync(tempSegment,SocketFlags.None);
                    }
                    RecieveDataEvent?.Invoke(dataSegment.Array,serverIPEndPoint);
                }catch(ObjectDisposedException){
                    return;
                }catch(SocketException){
                    ConnectionShutdown?.Invoke(serverIPEndPoint);
                    if(!AutoReconnect)
                        await Reconnect();                   
                }
            }
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Disconnect();
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
