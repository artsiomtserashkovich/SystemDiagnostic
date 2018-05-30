using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IProcessInformationRepository : IRepository<ProcessInformation>
    {
        ProcessInformation GetProcessInformationByProcessId(string processId);
    }
}
