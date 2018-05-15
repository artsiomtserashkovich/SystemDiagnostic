using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient
{
    public class ClientResponseHandler : BaseClientResponseHandler
    {
        public ClientResponseHandler()
            : base(typeof(ClientCommandHandler)) { }
    }
}
