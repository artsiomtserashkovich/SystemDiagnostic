using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities
{
    public class ClientCommandDTO
    {
        public string IdCommand {get;set;}
        public string Command {get;set;}
        public ClientCommandInformation Information {get;set;}
    }
}
