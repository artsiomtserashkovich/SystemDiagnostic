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
            return _processPerfomanceService.GetTopCPUUsageProcessesPerfomances(20);
        }

        public IEnumerable<ProcessDTO> GetTopCPUUsageProcesses()
        {
            IEnumerable<ProcessPerfomanceDTO> processesPerfomance = _processPerfomanceService
                .GetTopCPUUsageProcessesPerfomances(10);
            IList<ProcessDTO> processes = new List<ProcessDTO>(20);
            foreach (ProcessPerfomanceDTO processPerfomance in processesPerfomance)
            {
                ProcessInformationDTO processInformation = _processInformationService
                    .GetProcessInformationById(processPerfomance.ProcessId);
                ProcessDTO process = new ProcessDTO
                {
                    Information = processInformation,
                    PerfomanceInformation = processPerfomance,
                    ProcessId = processPerfomance.ProcessId
                };
                processes.Add(process);
            }
            return processes;
        }

        public IEnumerable<ProcessDTO> GetTopMemoryUsageProcesses()
        {
            IEnumerable<ProcessPerfomanceDTO> processesPerfomance = _processPerfomanceService
                .GetTopMemoryUsageProcessesPerfomances(10);
            IList<ProcessDTO> processes = new List<ProcessDTO>(10);
            foreach (ProcessPerfomanceDTO processPerfomance in processesPerfomance)
            {
                ProcessInformationDTO processInformation = _processInformationService
                    .GetProcessInformationById(processPerfomance.ProcessId);
                ProcessDTO process = new ProcessDTO
                {
                    Information = processInformation,
                    PerfomanceInformation = processPerfomance,
                    ProcessId = processPerfomance.ProcessId
                };
                processes.Add(process);
            }
            return processes;
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
