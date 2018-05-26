using System;
using System.Collections.Generic;
using SystemDiagnostic.Diagnostic.Client.Services;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Controllers
{
    public class OperatingSystemMonitoringController
    {
        private ProcessPerfomanceService _processPerfomanceService;
        public OperatingSystemMonitoringController(
            ProcessPerfomanceService processPerfomanceService
        )
        {
            _processPerfomanceService = processPerfomanceService;
        }

        public IEnumerable<ProcessPerfomanceDTO> GetTopCPUUsageProcesses(){
            return _processPerfomanceService.GetTopCPUUsageProcessesPerfomances(10);
        }

        public IEnumerable<ProcessPerfomanceDTO> GetTopMemoryUsageProcesses(){
            return _processPerfomanceService.GetTopMemoryUsageProcessesPerfomances(10);
        }

        public ProcessPerfomanceDTO GetProcessPerfomanceById(int id){
            return _processPerfomanceService.GetProcessPerfomanceById(id);
        }

        public ProcessPerfomanceDTO GetProcessPerfomanceByName(string name){
            return _processPerfomanceService.GetProcessPerfomanceByName(name);
        }
    }
}
