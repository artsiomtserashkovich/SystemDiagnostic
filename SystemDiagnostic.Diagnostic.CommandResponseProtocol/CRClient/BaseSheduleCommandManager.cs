using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities
{
    public class BaseSheduleCommandManager : IScheduleCommandManager
    {
        public void SetClientMediator(IClientMediator clientMediator)
        {
            throw new NotImplementedException();
        }
    }
}
