using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Attributes
{
    public class CRCommandHandlerAttribute : Attribute
    {
        public string Command {get;set;}
        public CRCommandHandlerAttribute(string command){
            Command = command;
        }
    }
}
