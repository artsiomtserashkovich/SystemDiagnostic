using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Entities
{
    public class WMIProcessor
    {
        [WMI(WMIProcessorProperties.ProcessorId)]
        public string Id { get; set; }

        [WMI(WMIProcessorProperties.Name)]
        public string Name { get; set; }

        [WMI(WMIProcessorProperties.Description)]
        public string Description { get; set; }

        [WMI(WMIProcessorProperties.NumberOfCores)]
        public int NumberOfCores { get; set; }

        [WMI(WMIProcessorProperties.MaxClockSpeed)]
        public int ClockFrequency { get; set; }

        [WMI(WMIProcessorProperties.SocketDesignation)]
        public string Socket { get; set; }

        [WMI(WMIProcessorProperties.Architecture)]
        public int Architecture { get; set; }

        [WMI(WMIProcessorProperties.L2CacheSize)]
        public int L2Cache { get; set; }

        [WMI(WMIProcessorProperties.L3CacheSize)]
        public int L3Cache { get; set; }
    }
}
