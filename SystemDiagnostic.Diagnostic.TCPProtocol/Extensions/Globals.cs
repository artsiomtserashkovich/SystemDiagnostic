using System;
using System.Net;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Extensions
{
    public delegate void CloseSocket(IPEndPoint closeSocket);
    public delegate void RecieveDataSocket(string message, IPEndPoint sender);

    internal static class Constans
    {
        internal const int SendBufferLength  = 1024;
        internal const int RecieveBufferLength  = 1024;
        internal const int TimeOutPing  = 5000;
        internal const int MaxBackLogConnections  = 20; 
        internal const int ReconnectInterval  = 500;
    }    

    //TODO : Implement Exceptions

    public class TransferException : Exception {
        public TransferException(string message) : base(message) { }
    }
    public class NotFoundException : Exception {
        public NotFoundException(string message) : base(message) { }
    }
    public class GenericProtocolException : Exception {
        public GenericProtocolException(string message) : base(message) { }
    }
}
