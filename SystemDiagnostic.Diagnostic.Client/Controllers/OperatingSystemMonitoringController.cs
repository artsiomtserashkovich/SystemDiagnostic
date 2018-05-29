using System;
using System.Collections.Generic;
using SystemDiagnostic.Diagnostic.Client.Services;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Controllers
{
    public class OperatingSystemMonitoringController
    {
        private ProcessPerfomanceService _processPerfomanceService;
        private ProcessInformationService _processInformationService;

        public OperatingSystemMonitoringController(
            ProcessPerfomanceService processPerfomanceService,
            ProcessInformationService processInformationService
        )
        {
            _processInformationService = processInformationService;
            _processPerfomanceService = processPerfomanceService;
        }

        public IEnumerable<ProcessPerfomanceDTO> GetTopCPUUsageProcessesPerfomance()
        {
            return _processPerfomanceService.GetTopCPUUsageProcessesPerfomances(10);
        }

        public IEnumerable<ProcessDTO> GetTopCPUUsageProcesses()
        {

        }

        public IEnumerable<ProcessDTO> GetTopMemoryProcesses()
        {

        }

        public IEnumerable<ProcessPerfomanceDTO> GetTopMemoryUsageProcessesPerfomance()
        {
            return _processPerfomanceService.GetTopMemoryUsageProcessesPerfomances(10);
        }

        public ProcessPerfomanceDTO GetProcessPerfomanceById(int id)
        {
            return _processPerfomanceService.GetProcessPerfomanceById(id);
        }

        public ProcessPerfomanceDTO GetProcessPerfomanceByName(string name)
        {
            return _processPerfomanceService.GetProcessPerfomanceByName(name);
        }
    }
}
