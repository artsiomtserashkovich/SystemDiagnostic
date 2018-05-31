using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.DAL.Repositories
{
    public class ProcessInformationRepository : Repository<ProcessInformation> , IProcessInformationRepository 
    {
        public ProcessInformationRepository(ApplicationDataBaseContext applicationDataBaseContext) 
            : base(applicationDataBaseContext) { }

        public ProcessInformation GetProcessInformationByProcessId(string processId)
        {
            return _DbSet.FirstOrDefault(p => p.ProcessId == processId);
        }
    }
}
