using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.BLL.Interfaces
{
    public interface IProcessorService
    {
        Processor GetProcessorById(string id);
        IEnumerable<Processor> GetProcessors();
        bool DeleteProcessorById(string id);
    }
}
