using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class ProcessInformationDTO
    {
        public int ProcessId {get;set;}
        public DateTime CreationDate {get;set;}
        public string Description {get;set;}
        public string Path {get;set;}
        public string Name {get;set;}
        public string CommandLine {get;set;}
    }
}
