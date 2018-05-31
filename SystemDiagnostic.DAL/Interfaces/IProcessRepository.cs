using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IProcessRepository : IRepository<Process>
    { 
        IEnumerable<Process> GetProcessesByComputerId(string computerId);
    }
}
