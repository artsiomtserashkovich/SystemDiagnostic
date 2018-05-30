using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IProcessorRepository:IRepository<Processor>
    {
        Processor GetProcessorByComputerId { get; set; }
        Processor GetProcessorByСomputerLogin { get; set; }
    }
}
