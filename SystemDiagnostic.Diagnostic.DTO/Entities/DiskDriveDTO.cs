using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class DiskDriveDTO
    {
        public string Id {get;set;}
        public string Model {get;set;}
        public ulong Size {get;set;}
        public string MediaType {get;set;}
    }
}
