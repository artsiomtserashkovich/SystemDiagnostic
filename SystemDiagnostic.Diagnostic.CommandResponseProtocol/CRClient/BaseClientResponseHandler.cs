using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient
{
    public abstract class BaseClientResponseHandler : IClientResponseHandler
    {
        public void HandleServerResponse(ServerResponseDTO serverResponse)
        {
            throw new NotImplementedException();
        }

        public void SetClientMediator(IClientMediator clientMediator)
        {
            throw new NotImplementedException();
        }
    }
}
