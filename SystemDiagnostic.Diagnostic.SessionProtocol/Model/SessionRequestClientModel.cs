using System;

namespace SystemDiagnostic.Diagnostic.SessionProtocol.Model
{
    public class SessionRequestClientModel
    {
        public string Method {get;set;}
        public DateTime RequestTime {get;set;}
        public string ClientIdentificator {get;set;}
        public byte[] Data {get;set;}
    }
}
