using System;

namespace SystemDiagnostic.Diagnostic.SessionProtocol.Model
{
    public class SessionRequestServerModel
    {
        public string Method {get;set;}
        public string ServerIdentificator {get;set;}
        public DateTime RequestTime {get;set;}
    }
}
