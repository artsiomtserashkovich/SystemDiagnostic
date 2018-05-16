using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities
{
    public class ServerResponseInformation
    {
        public int Status {get;set;}
        
        public string SerializedData {get;set;}
    }
}
