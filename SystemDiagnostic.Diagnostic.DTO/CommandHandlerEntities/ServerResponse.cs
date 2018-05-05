using System;

namespace SystemDiagnostic.Diagnostic.DTO.CommandHandlerEntities
{
    public class ServerResponse
    {
        public string Command {get;set;}
        public int Status {get;set;}
        public string Arguments{get;set;}
    }
}
