using System;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Extensions
{
    internal static class TCPSegmentSizeFormater
    {
        internal static int SegmentIdentificatorSize { get; set; } = Constans.SegmentIdentificatorSize;

        internal static async Task<int> ReceuiveTCPSegmentSize(Socket socket)
        {
            try
            {
                int segmentSize;
                byte[] segmentSizeBytes = new byte[SegmentIdentificatorSize];
                ArraySegment<byte> segmentSizeBytesSegment = new ArraySegment<byte>(segmentSizeBytes);
                int readSize = await socket.ReceiveAsync(segmentSizeBytesSegment, SocketFlags.None);
                if (readSize < 1)
                    throw new TransferException($"{readSize} was read. Connection shutdown.");
                segmentSize = BitConverter.ToInt32(segmentSizeBytesSegment.Array, 0);
                return segmentSize;
            }
            catch (ArgumentException ex)
            {
                throw new TransferException("Undefined type of recieve transfer data.",ex);
            }           
        }

        internal static async Task SendTCPSegmentSize(Socket socket, int tcpSegmentSize)
        {
            try{
                byte[] segmentSize = BitConverter.GetBytes(tcpSegmentSize);
                ArraySegment<byte> segmentSizeSegment = new ArraySegment<byte>(segmentSize);
                int sent =  await socket.SendAsync(segmentSizeSegment,SocketFlags.None);
                if(sent < 1 )
                    throw new TransferException($"{sent} bytes sent.Connection shutdown.");
            }
            catch(SocketException excep){
                throw new TransferException("Connection is enterrupted.",excep);                
            }

        }
    }
}
