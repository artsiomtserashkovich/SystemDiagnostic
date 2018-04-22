using System;
using System.Net;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Extensions
{
    public delegate void SocketAction(IPEndPoint closeSocket);
    public delegate void RecieveDataSocket(byte[] message, IPEndPoint sender);

    internal static class Constans
    {
        internal const int SegmentIdentificatorSize = 4;
        internal const int SendBufferSize  = 1024;
        internal const int RecieveBufferSize  = 1024;
        internal const int TimeOutPing  = 5000;
        internal const int MaxBackLogConnections  = 20; 
        internal const int ReconnectInterval  = 500;
    }
    
    public class TransferException : Exception {
        public TransferException(string message) : base(message) { }
        public TransferException(string message,Exception innerException) : base(message,innerException) {}
    }
    public class NotFoundException : Exception {
        public NotFoundException(string message) : base(message) { }
    }
    public class TCPProtocolException : Exception {
        public TCPProtocolException(string message) : base(message) { }
        public TCPProtocolException(string message,Exception inner) : base(message,inner) {} 
    }
}
