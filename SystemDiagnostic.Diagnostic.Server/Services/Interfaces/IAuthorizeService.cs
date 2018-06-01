using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDiagnostic.Diagnostic.Server.Services.Interfaces
{
    interface IAuthorizeService
    {
        bool CheckLogin(string computerLogin);
        bool CheckAuthorize(string computerLogin, string computerPassword);
    }
}
