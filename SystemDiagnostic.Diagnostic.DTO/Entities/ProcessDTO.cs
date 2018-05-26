using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class ProcessDTO
    {
        public ProcessPerfomanceDTO PerfomanceInformation {get;set;}
        public ProcessInformationDTO Information {get;set;}
        public int ProcessId {get;set;}      
    }
}
