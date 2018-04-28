using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class DiskDriveDTO
    {
        public string Id {get;set;}
        public string Model {get;set;}
        public double SizeGB {get;set;}
        public string MediaType {get;set;}
    }
}
