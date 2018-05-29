using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDiagnostic.Diagnostic.Server.Services.Exceptions
{
    class ServerServicesException : Exception
    {
        public ServerServicesException() : base() {}

        public ServerServicesException(string message) : base(message) { }

        public ServerServicesException(string message, Exception innerException) : base(message, innerException) { }
    }
}
