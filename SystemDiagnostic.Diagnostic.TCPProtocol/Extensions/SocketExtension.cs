using System;
using System.Net.Sockets;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Extensions
{
    public static class SocketExtensions {
        public static bool Ping(this Socket socket) {
            try {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            } catch (SocketException) {
                return false;
            } catch (ObjectDisposedException) {
                return false;
            }
        }
    }
}
