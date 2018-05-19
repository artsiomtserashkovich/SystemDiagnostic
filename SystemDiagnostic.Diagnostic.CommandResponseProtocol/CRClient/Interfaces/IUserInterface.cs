using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    public interface IUserInterface
    {
        void SetClientMediator(IClientMediator clientMediator);
        void OutputMessage(UIOutputModel outputModel);
        ClientCommandRequest InputCommand(UIOutputModel outputModel);
        ClientLoginModel InputLogin(UIOutputModel outputModel);
        RunInputModel InputRunProperties(UIOutputModel outputModel);
        RunInputModel InputRunProperties();
        ClientLoginModel InputLogin();
        ClientLoginModel InputLoginToRegister();
    }
}