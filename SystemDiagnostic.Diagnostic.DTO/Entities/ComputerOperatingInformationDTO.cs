using System;
using System.Collections.Generic;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class ComputerOperatingInformationDTO
    {
        public ComputerSystemDTO ComputerInformation {get;set;}
        public IEnumerable<ProcessDTO> CurrentProcesses {get;set;}
    }
}
