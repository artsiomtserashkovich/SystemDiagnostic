using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    internal interface IClientMediator
    {
       void HandleResponse(ServerResponseDTO serverResponse);
       ClientCommandDTO ProducingClientCommand(ClientCommandRequest ClientCommandRequest);
       void SendClientCommand(ClientCommandDTO clientCommand);
       void RequestForInputCommand(UserInterfaceForm commandRequest);
       void 
    }
}
