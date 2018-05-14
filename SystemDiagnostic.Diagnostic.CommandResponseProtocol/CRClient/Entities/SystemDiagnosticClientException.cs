using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities
{
    public class SystemDiagnosticClientException : Exception
    {
        public SystemDiagnosticClientException(string message) : base(message) {}
        public SystemDiagnosticClientException(Exception innerException,string message) 
            : base(message,innerException) {}
    }
}
