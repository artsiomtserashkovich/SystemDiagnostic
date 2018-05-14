using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient
{
    public abstract class BaseClientCommandHandler : IClientCommandHandler
    {
        public ClientCommandDTO HandleClientCommandRequest(ClientCommandRequest clientCommandRequest, ClientLoginModel clientLoginModel)
        {
            throw new NotImplementedException();
        }

        public void SetClientMediator(IClientMediator clientMediator)
        {
            throw new NotImplementedException();
        }
    }
}
