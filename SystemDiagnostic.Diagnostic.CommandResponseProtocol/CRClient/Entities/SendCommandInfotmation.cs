using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities{
    internal class SendCommandInformation{
        public ClientCommandDTO Command {get;set;}
        public DateTime SendTime {get;set;}
        public int CountResend {get;set;}

        public SendCommandInformation(ClientCommandDTO clientCommand){
            Command = clientCommand;
            SendTime = DateTime.Now;
            CountResend = 0;
        }        
    }
}