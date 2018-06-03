using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IPhysicalMemoryService
    {
        PhysicalMemory GetPhysicalMemoryById(string id);
        bool DeletePhysicalMemoryById(string id);
        IEnumerable<PhysicalMemory> GetPhysicalMemories();
    }
}
