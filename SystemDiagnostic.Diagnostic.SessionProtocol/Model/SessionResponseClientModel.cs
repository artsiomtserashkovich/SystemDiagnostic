using System;

namespace SystemDiagnostic.Diagnostic.SessionProtocol.Model
{
    public class SessionResponseClientModel
    {
        public string ResponseStatus {get;set;}
        public byte[] Data {get;set;}
    }
}
