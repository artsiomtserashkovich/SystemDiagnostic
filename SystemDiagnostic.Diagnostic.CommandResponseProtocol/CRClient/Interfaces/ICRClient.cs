using System;
using System.Net;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    internal interface ICRClient : IDisposable
    {
        void Run(IPAddress address, int port);
        void RecieveUserCommand(ClientCommandDTO newClientCommand);
    }
}
