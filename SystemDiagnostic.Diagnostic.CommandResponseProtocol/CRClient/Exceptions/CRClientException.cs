using System;
using System.Runtime.Serialization;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Exceptions
{
    [Serializable]
    internal class CRClientException : Exception
    {
        public CRClientException()
        {
        }

        public CRClientException(string message) : base(message)
        {
        }

        public CRClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CRClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}