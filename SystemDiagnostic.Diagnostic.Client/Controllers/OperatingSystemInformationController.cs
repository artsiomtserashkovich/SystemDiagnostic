using System;
using System.Collections.Generic;
using SystemDiagnostic.Diagnostic.Client.Services;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Controllers
{
    public class OperatingSystemInformationController
    {
        private ComputerSystemInformationService _computerSystemService;
        private ProcessInformationService _processInformationService;
        private ProcessPerfomanceService _processPerfomanceService;
        public OperatingSystemInformationController(
            ComputerSystemInformationService computerSystemService,
            ProcessInformationService processInformationService,
            ProcessPerfomanceService processPerfomanceService
        )
        {
            _computerSystemService = computerSystemService;
            _processInformationService = processInformationService;
            _processPerfomanceService = processPerfomanceService;
        }

        public ProcessInformationDTO GetProcessInformationById(int processId){
            return _processInformationService.GetProcessInformationById(processId);
        }

        public ProcessInformationDTO GetProcessInformationByName(string name){
            return _processInformationService.GetProcessInformationByName(name);
        }

        public ComputerSystemDTO GetComputerSystemInformation()
        {
            return _computerSystemService.GetComputerSystemInformation();
        }

        public ComputerOperatingInformationDTO GetComputerOperatingInformation(){
            IEnumerable<ProcessPerfomanceDTO> processesPerfomance = _processPerfomanceService
                .GetTopCPUUsageProcessesPerfomances(10);
            IList<ProcessDTO> processes = new List<ProcessDTO>(10);
            foreach(ProcessPerfomanceDTO processPerfomance in processesPerfomance){
                ProcessInformationDTO processInformation = _processInformationService
                    .GetProcessInformationById(processPerfomance.ProcessId);
                ProcessDTO process = new ProcessDTO{
                    Information = processInformation,
                    PerfomanceInformation = processPerfomance,
                    ProcessId = processPerfomance.ProcessId
                };
                processes.Add(process);
            } 
            return new ComputerOperatingInformationDTO{
                ComputerInformation = _computerSystemService.GetComputerSystemInformation(),
                CurrentProcesses  = processes
            };
        }
    }
}
