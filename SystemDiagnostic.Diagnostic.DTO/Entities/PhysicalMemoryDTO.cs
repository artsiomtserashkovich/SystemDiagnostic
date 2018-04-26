using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class PhysicalMemoryDTO
    {
        public string Id{get;set;}
        public ulong Capacity{get;set;}
        public string FormFactor {get;set;}
        public string Manufacurer {get;set;}
        public uint Speed {get;set;}
    }
}
