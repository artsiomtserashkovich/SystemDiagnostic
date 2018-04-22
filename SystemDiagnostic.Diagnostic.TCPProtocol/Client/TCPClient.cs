using System;
using System.Threading.Tasks;
using SystemDiagnostic.Diagnostic.TCPProtocol.Extensions;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;

namespace SystemDiagnostic.Diagnostic.TCPProtocol.Client
{
    public class TCPClient : IClient
    {
        public bool AutoReconnect { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SendBufferLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int RecieveBufferLength { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TimeOutPing { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event RecieveDataSocket RecieveDataEvent;
        public event SocketAction ConnectionShutdown;
        public event SocketAction Connected;

        public Task Connect()
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public Task SendData(byte[] data)
        {
            throw new NotImplementedException();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TCPClient() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
