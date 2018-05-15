using System;
using System.Runtime.Serialization;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities
{
    [Serializable]
    public class ResponseHandlerException : Exception
    {
        public ResponseHandlerException()
        {
        }

        public ResponseHandlerException(string message) : base(message)
        {
        }

        public ResponseHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResponseHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}