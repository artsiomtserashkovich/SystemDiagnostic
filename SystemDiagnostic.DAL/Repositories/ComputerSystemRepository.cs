using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.OperatingInformation;

namespace SystemDiagnostic.DAL.Repositories
{
    class ComputerSystemRepository : Repository<ComputerSystem> , IComputerSystemRepository
    {
        public ComputerSystemRepository(ApplicationDataBaseContext applicationDataBaseContext) 
            : base(applicationDataBaseContext) { }

        public ComputerSystem GetByComputerId(string computerId)
        {
            return _DbSet.FirstOrDefault(c => c.ComputerId == computerId);
        }
    }
}
