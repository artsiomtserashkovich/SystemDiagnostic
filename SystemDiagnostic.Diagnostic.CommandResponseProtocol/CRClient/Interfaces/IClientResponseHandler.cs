using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    public interface IClientResponseHandler
    {
        void SetClientMediator(IClientMediator clientMediator);
        void HandleServerResponse(ServerResponseDTO serverResponse);
    }
}
