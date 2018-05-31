using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IDiskDriveRepository : IRepository<DiskDrive>
    {
        IEnumerable<DiskDrive> GetDiskDrivesByComputerId(string computerId);
    }
}
