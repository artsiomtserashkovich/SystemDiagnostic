using System;
using System.Net;

namespace SystemDiagnostic.Diagnostic.Server.NetworkServer
{
    public class ClientInformation
    {
        public ClientInformation(IPEndPoint ipAddress){
            IpAddress = ipAddress; 
            Id = Guid.NewGuid().ToString();
            IsLogin = false;
            Login = string.Empty;
        }
        public IPEndPoint IpAddress {get;set;}
        public string Id {get;set;}
        public bool IsLogin {get;set;}
        public string Login {get;set;}
    }
}
