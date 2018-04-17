using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Entities
{
    public class WMIPhysicalMemory
    {
        [WMI(WMIPhysicalMemoryProperties.PartNumber)]
        public string Id { get; set; }

        [WMI(WMIPhysicalMemoryProperties.Capacity)]
        public ulong Capacity { get; set; }

        [WMI(WMIPhysicalMemoryProperties.FormFactor)]
        public string FormFactor { get; set; }

        [WMI(WMIPhysicalMemoryProperties.Manufacturer)]
        public string Manufacturer { get; set; }

        [WMI(WMIPhysicalMemoryProperties.Speed)]
        public uint Speed { get; set; }

    }
}
