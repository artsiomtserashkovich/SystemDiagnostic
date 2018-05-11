using System;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces
{
    internal interface IClientMediator
    {
        ICRClient CRClient {get;set;}
        IUserInterface UserInterface {get;set;}
        IClientResponseHandler ClientResponseHandler {get;set;}
        IClientCommandHandler ClientCommandHandler {get;set;}
        IScheduleManager ScheduleManager {get;set;}
    }
}
