using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces
{
    public interface IServer
    {
        int SendBufferLength {get;set;}
        int RecieveBufferLength {get;set;}
        int TimeOutPing {get;set;}
        IEnumerable<IPEndPoint> Clients {get;}
        void Start(int maxBacklogConnection);
        void Stop();
        Task SendData(string data,IPEndPoint recipient);
        Task BroadCastData(string data);
        bool Kick(IPEndPoint client);
    }
}
