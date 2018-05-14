using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    public interface IScheduleCommandManager
    {
        void SetClientMediator(IClientMediator clientMediator);
    }
}