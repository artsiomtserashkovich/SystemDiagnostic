using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.DAL.Repositories
{
    public class PhysicalMemoryRepository : Repository<PhysicalMemory>, IPhysicalMemoryRepository
    {
        public PhysicalMemoryRepository(ApplicationDataBaseContext applicationDataBaseContext) 
            : base(applicationDataBaseContext) { }

        public IEnumerable<PhysicalMemory> GetPhysicalMemoriesByComputerId(string computerId)
        {
            return _DbSet.Where(p => p.ComputerId == computerId);
        }

        public IEnumerable<PhysicalMemory> GetPhysicalMemoriesByComputerLogin(string computerLogin)
        {
            return _DbSet.Where(p => p.Computer.Login == computerLogin);
        }
    }
}
