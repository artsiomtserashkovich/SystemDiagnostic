using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.MonitoringInformation;

namespace SystemDiagnostic.DAL.Repositories
{
    public class ProcessRepository : Repository<Process> , IProcessRepository
    {
        public ProcessRepository(ApplicationDataBaseContext applicationDataBaseContext) 
            : base(applicationDataBaseContext) { }

        public Process GetProcessByComputerIdAndName(string computerId, string Name)
        {
            return _DbSet.FirstOrDefault(p => p.ComputerId == computerId && p.Name == Name);
        }

        public IEnumerable<Process> GetProcessesByComputerId(string computerId)
        {
            return _DbSet.Where(p => p.ComputerId == computerId);
        }
    }
}
