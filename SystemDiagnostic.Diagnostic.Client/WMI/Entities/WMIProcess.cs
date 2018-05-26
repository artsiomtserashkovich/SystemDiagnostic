using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Entities
{
    public class WMIProcess
    {
        [WMI(WMIProcessProperties.ProcessId)]
        public int Id {get;set;}
        [WMI(WMIProcessProperties.CreationDate)]
        public DateTime CreatinDate{get;set;}
        [WMI(WMIProcessProperties.Description)]
        public string Description {get;set;}
        [WMI(WMIProcessProperties.Name)]
        public string Name {get;set;}
        [WMI(WMIProcessProperties.ExecutablePath)]
        public string Path{get;set;}
        [WMI(WMIProcessProperties.PeakWorkingSetSize)]
        public ulong PeakWorkingSetSizeKB {get;set;}
        [WMI(WMIProcessProperties.CommandLine)]
        public string CommandLine {get;set;}
    }
}
