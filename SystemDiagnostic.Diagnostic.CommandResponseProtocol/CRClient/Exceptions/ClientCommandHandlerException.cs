using System;
using System.Runtime.Serialization;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Exceptions
{
    [Serializable]
    public class ClientCommandHandlerException : Exception
    {
        public ClientCommandHandlerException()
        {
        }

        public ClientCommandHandlerException(string message) : base(message)
        {
        }

        public ClientCommandHandlerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClientCommandHandlerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}