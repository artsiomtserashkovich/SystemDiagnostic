using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IProcessService
    {
        IEnumerable<Process> GetProcessesByComputerId(string computerId);
        Process GetProcessById(string id);
        Process GetProcessByNameAndComputerId(string name, string computerId);
        bool DeleteProcessById(string id);
    }
}
