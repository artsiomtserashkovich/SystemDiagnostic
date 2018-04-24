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
        int ReconnectTime {get;set;}
        bool isConnected {get;}
        event RecieveDataSocket RecieveDataEvent;
        event SocketAction ConnectionShutdown;
        event SocketAction Connected;
        Task SendDataAsync(byte[] data);
        void Disconnect();
        void Connect();
    }
}
