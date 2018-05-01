using System;
using System.Collections.Generic;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

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
        
        public ProcessDTO GetProcessById(int id){
            WMIProcess wmiProcess = _wmimanagers.WMIProcessManager.GetWMIProcessById(id);
            if(wmiProcess == null)
                return null;
            ProcessDTO process = _mapper.Map<WMIProcess,ProcessDTO>(wmiProcess);
            WMIPerfDataProcess wmiPerfDataProcess = _wmimanagers.WMIPerfDataProcessManager.GetWMIPerfDataProcessById(id);
            return wmiPerfDataProcess != null? _mapper.Map<WMIPerfDataProcess,ProcessDTO>(wmiPerfDataProcess,process) : process;        
        }
        public IEnumerable<ProcessDTO> GetProcesses (){
            IList<ProcessDTO> processes = new List<ProcessDTO>();
            IEnumerable<WMIProcess> wmiProcesses = _wmimanagers.WMIProcessManager.GetWMIProcesses();
            foreach(WMIProcess wmiProcess in wmiProcesses){
                ProcessDTO process = _mapper.Map<WMIProcess,ProcessDTO>(wmiProcess);
                WMIPerfDataProcess wmiPerfDataProcess = _wmimanagers.WMIPerfDataProcessManager
                    .GetWMIPerfDataProcessById(wmiProcess.Id);
                process = wmiPerfDataProcess!=null?
                    _mapper.Map<WMIPerfDataProcess,ProcessDTO>(wmiPerfDataProcess,process) : process;
                processes.Add(process);  
            }
            return processes;
        }
    }
}
