using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities
{
    public class ServerResponseDTO
    {
        public string Command {get;set;}
        public string IdCommand {get;set;}
        public ServerResponseInformation Information {get;set;}
    }
}
