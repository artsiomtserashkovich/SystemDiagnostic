using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.DAL.Repositories
{
    class ProcessorRepository : Repository<Processor>, IProcessorRepository
    {
        public ProcessorRepository(ApplicationDataBaseContext applicationDataBaseContext)
            : base(applicationDataBaseContext) { }

        public Processor GetProcessorByComputerId(string computerId)
        {
            return _DbSet.FirstOrDefault(c => c.ComputerId == computerId);
        }
    }
}
