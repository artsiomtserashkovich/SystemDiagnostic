using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Entities
{
    public class WMIPerfDataProcess
    {
        [WMI(WMIPerfDataProcessProperties.IDProcess)]
        public int Id {get;set;}
        [WMI(WMIPerfDataProcessProperties.Name)]
        public string Name {get;set;}
        [WMI(WMIPerfDataProcessProperties.PercentProcessorTime)]
        public int PercentProcessorTime {get;set;}
        [WMI(WMIPerfDataProcessProperties.ThreadCount)]
        public int ThreadCount {get;set;}
        [WMI(WMIPerfDataProcessProperties.WorkingSetPeak)]
        public ulong WorkingSetPeakBytes {get;set;}
    }
}
