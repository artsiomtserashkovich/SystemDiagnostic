using System;
using System.Runtime.Serialization;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer
{
    [Serializable]
    internal class ServerCommandHandleException : Exception
    {
        public ServerCommandHandleException()
        {
        }

        public ServerCommandHandleException(string message) : base(message)
        {
        }

        public ServerCommandHandleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ServerCommandHandleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}