using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Entities
{
    public class ClientCommand
    {
        public string ClientId{get;set;}
        public ClientCommandDTO ClientCommandData {get;set;}
    }
}
