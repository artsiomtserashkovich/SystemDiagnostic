using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    internal interface ICRClient : IDisposable
    {
        void RecieveUserCommand(ClientCommandDTO newClientCommand);
    }
}
