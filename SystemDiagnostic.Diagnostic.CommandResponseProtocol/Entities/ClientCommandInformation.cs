using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities
{
    public class ClientCommandInformation
    {
        public ClientLoginModel ClientLogin {get;set;}
        public string SerializedData {get;set;}
    }
}
