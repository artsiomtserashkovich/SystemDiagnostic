using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient
{
    public class ClientResponseHandler : BaseClientResponseHandler
    {
        public ClientResponseHandler()
            : base(typeof(ClientCommandHandler)) { }

        
        
        [CRResponseHandler(322)]
        public void TestResponseHandle(ServerResponseInformation serverResponse){
            Console.WriteLine(serverResponse.Status);
            Console.WriteLine(serverResponse.SerializedData);
        }
    }
}
