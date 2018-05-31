using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.DAL.Repositories
{
    public class DiskDriveRepository : Repository<DiskDrive>, IDiskDriveRepository
    {
        public DiskDriveRepository(ApplicationDataBaseContext applicationDataBaseContex)
            : base(applicationDataBaseContex) { }

        public IEnumerable<DiskDrive> GetDiskDrivesByComputerId(string computerId)
        {
            return _DbSet.Where(d => d.ComputerId == computerId);
        }
    }
}
