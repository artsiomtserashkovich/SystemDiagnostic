using System;
using System.Threading.Tasks;
using SystemDiagnostic.Diagnostic.TCPProtocol.Extensions;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces
{
    public interface IClient : IDisposable
    {
        bool AutoReconnect{get;set;}
        int SendBufferLength {get;set;}
        int RecieveBufferLength {get;set;}
        int TimeOutPing {get;set;}
        event RecieveDataSocket RecieveDataEvent;
        event SocketAction ConnectionShutdown;
        event SocketAction Connected;
        Task SendData(byte[] data);
        void Disconnect();
        Task Connect();
    }
}
