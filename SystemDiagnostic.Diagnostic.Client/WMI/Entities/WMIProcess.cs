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
        [WMI(WMIProcessProperties.CommandLine)]
        public string CommandLine {get;set;}
        [WMI(WMIProcessProperties.Name)]
        public string Name {get;set;}
        [WMI(WMIProcessProperties.Caption)]
        public string Caption {get;set;}
        [WMI(WMIProcessProperties.ExecutablePath)]
        public string Path{get;set;}
        [WMI(WMIProcessProperties.Status)]
        public string Status {get;set;}
        [WMI(WMIProcessProperties.ThreadCount)]
        public int ThreadCount {get;set;}
        [WMI(WMIProcessProperties.VirtualSize)]
        public ulong VirtualSize{get;set;}
        [WMI(WMIProcessProperties.WorkingSetSize)]
        public ulong WorkingSetSize {get;set;}
        [WMI(WMIProcessProperties.PeakVirtualSize)]
        public ulong PeakVirtualSize {get;set;}
        [WMI(WMIProcessProperties.PeakWorkingSetSize)]
        public ulong PeakWorkingSetSize {get;set;}
    }
}
