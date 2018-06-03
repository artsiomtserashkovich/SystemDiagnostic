using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IDiskDriveService
    {
        DiskDrive GetDiskDriveById(string id);
        IEnumerable<DiskDrive> GetDiskDrives();
        bool DeleteDiskDriveById(string id);
    }
}
