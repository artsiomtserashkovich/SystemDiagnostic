using System;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    public interface IScheduleCommandManager : IDisposable
    {
        void SetClientMediator(IClientMediator clientMediator);
        void Run();
        void Stop();
        void AddTimer(ClientCommandRequest clientCommand,int elapsedTimeSec, bool repeat);
        bool IsStart {get;}
    }
}