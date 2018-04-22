using System;
using System.Threading.Tasks;
using SystemDiagnostic.Diagnostic.TCPProtocol.Extensions;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces
{
    public interface IClient
    {
        int SendBufferLength {get;set;}
        int RecieveBufferLength {get;set;}
        int TimeOutPing {get;set;}
        event RecieveDataSocket RecieveDataEvent;
        event SocketAction SystemCloseEvent;
        Task SendData(byte[] data);
        void Disconnect();
        Task Connect();
    }
}
