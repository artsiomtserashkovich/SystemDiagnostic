using System;
using System.Net;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer.Entities
{
    public class RunPropertyModel
    {
        public IPAddress IPAddress {get;set;}
        public int ClientsCount {get;set;}
        public int Port {get;set;}
    }
}
