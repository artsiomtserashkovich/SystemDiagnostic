using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IProcessPerfomance
    {
        ProcessPerfomance GetProcessPerfomanceById(string id);
        ProcessPerfomance GetProcessPerfomanceByProcessId(string id, DateTime start, DateTime end);
        bool DeleteProcessPerfomancebyId(string id);
    }
}
