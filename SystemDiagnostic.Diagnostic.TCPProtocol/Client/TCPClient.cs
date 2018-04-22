using System;
using System.Threading.Tasks;
using SystemDiagnostic.Diagnostic.TCPProtocol.Extensions;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Client
{
    public class TCPClient : IClient
    {
        public int SendBufferLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RecieveBufferLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TimeOutPing { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event RecieveDataSocket RecieveDataEvent;
        public event SocketAction SystemCloseEvent;

        public Task Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Task SendData(byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
