using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.Interfaces
{
    public interface IServerCommandHandler
    {
        ServerResponseDTO HandleCommand(ClientCommandDTO clientCommand);
    }
}
