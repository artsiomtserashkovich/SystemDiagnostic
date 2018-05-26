using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class ProcessPerfomanceDTO
    {
        public int ProcessId {get;set;}
        public string Name {get;set;}
        public int PercentCPUUsage {get;set;}
        public int RamMemoryUsageMB {get;set;}
    }
}
