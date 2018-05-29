using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient
{
    public class ClientResponseHandler : BaseClientResponseHandler
    {
        public ClientResponseHandler()
            : base(typeof(ClientResponseHandler)) { }        
        
        [CRResponseHandler(999)]
        public void TestResponseHandler(ServerResponseInformation serverResponse,string command){
            Console.WriteLine(serverResponse.Status);
            Console.WriteLine(serverResponse.SerializedData);
        }

        [CRResponseHandler(2)]
        public void BadLoginResponseHandler(ServerResponseInformation serverResponse,string command)
        {
            _clientMediator.UnAuthrorize();
            Console.WriteLine(serverResponse.SerializedData);
        }

        [CRResponseHandler(1)]
        public void SuccessResponseHandler(ServerResponseInformation serverResponse, string command)
        {
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine("Success handle of command" + command +".");
        }
    }
}
