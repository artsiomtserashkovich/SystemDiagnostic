using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient
{
    public class ClientCommandHandler : BaseClientCommandHandler
    {
        private IServiceProvider _serviceProvider;
        public ClientCommandHandler (IServiceProvider serviceProvider) 
            : base(typeof(ClientCommandHandler))
            {
                _serviceProvider = serviceProvider;
            }
    }
}
