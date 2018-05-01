using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class ProcessDTO
    {
        public DateTime CreationDate {get;set;}
        public string Description {get;set;}
        public int ProcessId {get;set;}
        public string Path {get;set;}
        public string Name {get;set;}
        public int PercentProcessorTime {get;set;}
        public double WorkingSetSizeMB {get;set;}
        public double PeakWorkingSetSizeMB {get;set;}
        public double VirtualSizeMB {get;set;}
        public double PeakVirtualSizeMB {get;set;}
    }
}
