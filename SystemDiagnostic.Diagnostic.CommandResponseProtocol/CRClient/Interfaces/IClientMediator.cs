using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    public interface IClientMediator
    {
        void HandleResponse(ServerResponseDTO serverResponse);
        ClientCommandDTO ProducingClientCommand(ClientCommandRequest ClientCommandRequest);
        void SendClientCommand(ClientCommandDTO clientCommand);
        void OutputUIMessage(UIOutputModel messageModel);
        ClientCommandRequest UIInputCommand(UIOutputModel inputModel);        
    }
}
