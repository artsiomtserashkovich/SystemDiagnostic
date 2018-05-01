using System;

namespace SystemDiagnostic.Diagnostic.SessionProtocol.Model
{
    public class SessionResponseServerModel
    {
        public string ResponseStatus {get;set;}
        public byte[] Data {get;set;}
    }
}
