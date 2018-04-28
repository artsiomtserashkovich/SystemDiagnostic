using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class PhysicalMemoryDTO
    {
        public string Id{get;set;}
        public double CapacityGB {get;set;}
        public string FormFactor {get;set;}
        public string Manufacurer {get;set;}
        public uint Speed {get;set;}
    }
}
