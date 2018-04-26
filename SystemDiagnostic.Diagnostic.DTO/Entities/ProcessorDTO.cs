using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class ProcessorDTO
    {
        public string Id {get;set;}
        public string Name {get;set;}
        public int NumberOfCores {get;set;}
        public string Description {get;set;}
        public int ClockFrequency {get;set;}
        public string Architecture {get;set;}
        public int L2CacheSize {get;set;}
        public int L3CacheSize {get;set;}
    }
}
