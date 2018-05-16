using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes
{
    public class CRCommandHandlerAttribute : Attribute
    {
        public string Command {get;set;}
        public CRCommandHandlerAttribute(string command){
            Command = command;
        }
    }
}
