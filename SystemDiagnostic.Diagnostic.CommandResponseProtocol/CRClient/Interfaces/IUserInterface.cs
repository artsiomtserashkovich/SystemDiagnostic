using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities{
    public interface IUserInterface{
        event UserAction UserInvokeCommand;  
    }
}