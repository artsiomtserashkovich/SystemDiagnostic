using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer;

namespace SystemDiagnostic.Diagnostic.Server.NetworkServer
{
    public class ServerCommandHandler : BaseServerCommandHandler
    {
        public ServerCommandHandler() : base(typeof(ServerCommandHandler))
        {
        }
    }
}
