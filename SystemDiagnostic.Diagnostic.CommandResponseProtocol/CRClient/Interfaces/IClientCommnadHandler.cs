using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    public interface IClientCommandHandler
    {
        ClientCommandDTO HandleClientCommandRequest(ClientCommandRequest clientCommandRequest,ClientLoginModel clientLoginModel);
    }
}