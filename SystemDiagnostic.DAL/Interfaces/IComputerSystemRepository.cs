using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.OperatingInformation;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IComputerSystemRepository : IRepository<ComputerSystem>
    {
        ComputerSystem GetByComputerId(string computerId);
    }
}
