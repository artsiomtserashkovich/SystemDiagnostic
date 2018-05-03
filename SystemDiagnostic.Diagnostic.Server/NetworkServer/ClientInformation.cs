using System;

namespace SystemDiagnostic.Diagnostic.Server.NetworkServer
{
    public class ClientInformation
    {
        public ClientInformation(){
            Id = Guid.NewGuid().ToString();
            IsLogin = false;
            Login = string.Empty;
        }
        public string Id {get;set;}
        public bool IsLogin {get;set;}
        public string Login {get;set;}
    }
}
