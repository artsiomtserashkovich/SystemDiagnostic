using System;
using System.Net;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities
{
    public class RunInputModel
    {
        public IPAddress IPAddress{get;set;}
        public int Port{get;set;}
    }
}
