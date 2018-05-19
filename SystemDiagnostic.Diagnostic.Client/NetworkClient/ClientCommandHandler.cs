using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient
{
    public class ClientCommandHandler : BaseClientCommandHandler
    {
        private IServiceProvider _serviceProvider;
        public ClientCommandHandler(IServiceProvider serviceProvider)
            : base(typeof(ClientCommandHandler))
        {
            _serviceProvider = serviceProvider;
        }
        
        [CRCommandHandler("Test")]
        public string TestCommandHandle(ClientCommandRequest clientCommandRequest)
        {
            return "Test Command";
        }

        [CRCommandHandler("RegisterComputerComponent")]
        public string RegisterComputerComponentCommandHandle(ClientCommandRequest clientCommandRequest)
        {
            throw new NotImplementedException();
        }


    }
}
