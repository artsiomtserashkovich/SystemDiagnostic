using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Server.Services.Interfaces
{
    interface IProcessService
    {
        void UpdateProcessInformation(string computerLogin, ProcessInformationDTO processInfromation);
        void UpdateProcesses(string computerLogin, IEnumerable<ProcessDTO> processes);
        void UpdateProcessesInformation(string computerLogin, IEnumerable<ProcessInformationDTO> processesInformation);
        void AddProcessesPerfomance(string computerLogin, IEnumerable<ProcessPerfomanceDTO> processesPerfomance);
    }
}