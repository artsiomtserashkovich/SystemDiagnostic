using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.Server.Controllers
{
    public class AuthorizeController
    {
        public AuthorizeController() { }

        public ServerResponseInformation Authorize(ClientLoginModel clientLogin)
        {
            if (clientLogin.Login != "Login")
                return new ServerResponseInformation
                {
                    Status = 2,
                    SerializedData = "Bad Login"
                };
            else if (clientLogin.Password != "Password")
                return new ServerResponseInformation
                {
                    Status = 2,
                    SerializedData = "Bad Password"
                };
            else
                return null;
        }
    }
}
