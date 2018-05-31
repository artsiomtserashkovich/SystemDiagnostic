using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.DAL.Repositories
{
    public class ProcessPerfomanceRepository : Repository<ProcessPerfomance>, IProcessPerfomanceRepository
    {
        public ProcessPerfomanceRepository(ApplicationDataBaseContext applicationDataBaseContext) 
            : base(applicationDataBaseContext) { } 

        public IEnumerable<ProcessPerfomance> GetProcessPerfomancesByProcessId(string processId, int count, int page)
        {
            return _DbSet.Where(p => p.ProcessId == processId);
        }

        public IEnumerable<ProcessPerfomance> GetProcessPerfomancesByProcessIdAndDate(string processId, DateTime startDate, DateTime endDate)
        {
            return _DbSet.Where(p => ((p.ProcessId == processId) && (p.RecordDate >= startDate && p.RecordDate <= endDate)));
        }
    }
}
