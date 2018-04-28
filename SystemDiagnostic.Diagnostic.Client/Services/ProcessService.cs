using System;
using System.Collections.Generic;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class ProcessService
    {
        private readonly IWMIManagers _wmimanagers;
        private readonly IMapper _mapper;
        public ProcessService(IWMIManagers wmiManagers,IMapper mapper){
            _wmimanagers = wmiManagers;
            _mapper = mapper;
        }
        public IEnumerable<WMIProcess> GetProcesses(){
            return _wmimanagers.WMIProcessManager.GetWMIProcesses();
        }
    }
}
