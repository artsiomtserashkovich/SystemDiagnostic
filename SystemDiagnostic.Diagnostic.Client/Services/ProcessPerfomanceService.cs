using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class ProcessPerfomanceService
    {
        private readonly IWMIManagers _wmimanagers;
        private readonly IMapper _mapper;
        public ProcessPerfomanceService(IWMIManagers wmiManagers,IMapper mapper){
            _wmimanagers = wmiManagers;
            _mapper = mapper;
        }

        public ProcessPerfomanceDTO GetProcessPerfomanceById(int id){
            WMIPerfDataProcess wmiPerfDataProcess = _wmimanagers
                .WMIPerfDataProcessManager.GetWMIPerfDataProcessById(id);
            return wmiPerfDataProcess == null? null : _mapper
                .Map<WMIPerfDataProcess,ProcessPerfomanceDTO>(wmiPerfDataProcess);
        }

        public ProcessPerfomanceDTO GetProcessPerfomanceByName(string name){
            WMIPerfDataProcess wmiPerfDataProcess = _wmimanagers
                .WMIPerfDataProcessManager.GetWMIPerfDataProcessByName(name);
            return wmiPerfDataProcess == null? null : _mapper
                .Map<WMIPerfDataProcess,ProcessPerfomanceDTO>(wmiPerfDataProcess);
        }

        public IEnumerable<ProcessPerfomanceDTO> GetAllProcessesPerfomances(){
            IEnumerable<WMIPerfDataProcess> wmiPerfDataProcesses = _wmimanagers
                .WMIPerfDataProcessManager.GetWMIPerfDataProcesses();
            return _mapper.Map<IEnumerable<WMIPerfDataProcess>,IEnumerable<ProcessPerfomanceDTO>>
                (wmiPerfDataProcesses);
        }

        public IEnumerable<ProcessPerfomanceDTO> GetTopMemoryUsageProcessesPerfomances(int count){
            IEnumerable<WMIPerfDataProcess> wmiPerfDataProcesses = _wmimanagers
                .WMIPerfDataProcessManager.GetWMIPerfDataProcesses();
            IEnumerable<WMIPerfDataProcess> wmiTopMemoryUsagePerfDataProcesses 
                = wmiPerfDataProcesses.OrderByDescending(p => p.WorkingSetPeakBytes).Take(count);
            return wmiTopMemoryUsagePerfDataProcesses == null ? null : _mapper.Map<IEnumerable<WMIPerfDataProcess>,
                IEnumerable<ProcessPerfomanceDTO>>(wmiTopMemoryUsagePerfDataProcesses);
        }

        public IEnumerable<ProcessPerfomanceDTO> GetTopCPUUsageProcessesPerfomances(int count){
            IEnumerable<WMIPerfDataProcess> wmiPerfDataProcesses = _wmimanagers
                .WMIPerfDataProcessManager.GetWMIPerfDataProcesses();
            IEnumerable<WMIPerfDataProcess> wmiTopMemoryUsagePerfDataProcesses 
                = wmiPerfDataProcesses.OrderByDescending(p => p.PercentProcessorTime).Take(count);
            return wmiTopMemoryUsagePerfDataProcesses == null ? null : _mapper.Map<IEnumerable<WMIPerfDataProcess>,
                IEnumerable<ProcessPerfomanceDTO>>(wmiTopMemoryUsagePerfDataProcesses);
        }
    }
}