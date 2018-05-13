using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities
{
    public class ServerResponseDTO
    {
        public int Status {get;set;}
        public string Command {get;set;}
        public string IdCommand {get;set;}
        public string DataJSON {get;set;}
    }
}
