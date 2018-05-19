using System;
using System.Runtime.Serialization;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Exceptions
{
    [Serializable]
    public class ClientResponseHandlerException : Exception
    {
        public ClientResponseHandlerException()
        {
        }

        public ClientResponseHandlerException(string message) : base(message)
        {
        }

        public ClientResponseHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientResponseHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}