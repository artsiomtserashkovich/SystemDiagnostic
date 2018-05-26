using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class ProcessInformationService
    {
        private readonly IWMIManagers _wmimanagers;
        private readonly IMapper _mapper;
        public ProcessInformationService(IWMIManagers wmiManagers,IMapper mapper){
            _wmimanagers = wmiManagers;
            _mapper = mapper;
        }
        
        public ProcessInformationDTO GetProcessInformationById(int id){
            WMIProcess wmiProcess = _wmimanagers.WMIProcessManager.GetWMIProcessById(id);
            return wmiProcess == null? null 
                : _mapper.Map<WMIProcess,ProcessInformationDTO>(wmiProcess);
        }

        public ProcessInformationDTO GetProcessInformationByName(string name){            
            WMIProcess wmiProcess = _wmimanagers.WMIProcessManager.GetWMIProcessByName(name);
            return wmiProcess == null? null 
                : _mapper.Map<WMIProcess,ProcessInformationDTO>(wmiProcess);
        }

        public IEnumerable<ProcessInformationDTO> GetAllProcesses(){
            IEnumerable<WMIProcess> wmiProcesses = _wmimanagers
                .WMIProcessManager.GetWMIProcesses();
            return _mapper.Map<IEnumerable<WMIProcess>,IEnumerable<ProcessInformationDTO>>(wmiProcesses);
        }

        public IEnumerable<ProcessInformationDTO> GetTopProcessesByMemoryUsage(int count){
            IEnumerable<WMIProcess> wmiProcesses = _wmimanagers
                .WMIProcessManager.GetWMIProcesses();
            IEnumerable<WMIProcess> wmiTopProcesses = wmiProcesses.OrderByDescending(p => p.PeakWorkingSetSizeKB).Take(count);
            return _mapper.Map<IEnumerable<WMIProcess>,IEnumerable<ProcessInformationDTO>>(wmiTopProcesses);
        }
    }
}
