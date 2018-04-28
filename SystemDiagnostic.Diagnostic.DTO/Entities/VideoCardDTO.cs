using System;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class VideoCardDTO
    {
        public string Name { get; set; }
        public string VideoProcessor { get; set; }
        public double AdapterRAMGB { get; set; }
        public string AdapterCompatibility { get; set; }
        public uint MaxRefreshRate { get; set; }
    }
}
