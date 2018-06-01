using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;

namespace SystemDiagnostic.Diagnostic.Server.Controllers
{
    class AuthorizeController
    {
        private readonly IAuthorizeService _authorizeService;

        public AuthorizeController(IAuthorizeService authorizeService)
        {
            _authorizeService = authorizeService;
        }

        public ServerResponseInformation Authorize(ClientLoginModel clientLogin)
        {
            if (!_authorizeService.CheckLogin(clientLogin.Login))
                return new ServerResponseInformation
                {
                    Status = 2,
                    SerializedData = "Bad Login"
                };
            else if (!_authorizeService.CheckAuthorize(clientLogin.Login,clientLogin.Password))
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
