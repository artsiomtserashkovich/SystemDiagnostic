using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IProcessPerfomanceRepository : IRepository<ProcessPerfomance>
    {
        IEnumerable<ProcessPerfomance> GetProcessPerfomancesByProcessId(string processId,int count,int page);
        IEnumerable<ProcessPerfomance> GetProcessPerfomancesByProcessIdAndDate(string processId, DateTime startDate, DateTime endDate);
    }
}
