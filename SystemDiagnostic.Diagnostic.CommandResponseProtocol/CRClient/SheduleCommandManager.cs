using System;
using System.Collections.Generic;
using System.Timers;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;

namespace SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient
{
    public class ScheduleCommandManager : IScheduleCommandManager
    {
        private IClientMediator _clientMediator;
        private IDictionary<Timer,ClientCommandRequest> _scheduleCommands;
        public bool IsStart {get;private set;}

        public ScheduleCommandManager(){
            _scheduleCommands = new Dictionary<Timer,ClientCommandRequest>();
        }

        public void Run(){
            foreach(KeyValuePair<Timer,ClientCommandRequest> kvp in _scheduleCommands)
                kvp.Key.Start();
            IsStart = true;
        }

        private void TimerInvoke(object sender){
            ClientCommandRequest clientCommandRequest = new ClientCommandRequest();
            _scheduleCommands.TryGetValue((Timer)sender,out clientCommandRequest);
            ClientCommandDTO clientCommand 
                = _clientMediator.ProducingClientCommand(clientCommandRequest);
            _clientMediator.SendClientCommand(clientCommand);
        }
        
        public void SetClientMediator(IClientMediator clientMediator)
        {
            _clientMediator = clientMediator;
        }

        public void AddTimer(ClientCommandRequest clientCommand,int ElapsedTimeSec){
            Timer timer = new Timer(ElapsedTimeSec * 1000);
            timer.AutoReset = true;
            timer.Elapsed += ( sender, e ) => TimerInvoke(sender);
        }

        public void Stop()
        {
            foreach(KeyValuePair<Timer,ClientCommandRequest> kvp in _scheduleCommands)
                kvp.Key.Stop();
            IsStart = false;
        }

        public void Dispose()
        {
            foreach(KeyValuePair<Timer,ClientCommandRequest> kvp in _scheduleCommands)
                kvp.Key.Dispose();
        }
    }
}
