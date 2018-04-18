using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Entities
{
    public class WMIVideoController
    {
        [WMI(WMIVideoControllerProperties.Name)]
        public string Name {get;set;}

        [WMI(WMIVideoControllerProperties.VideoProcessor)]
        public string VideoProcessor {get;set;}

        [WMI(WMIVideoControllerProperties.AdapterRAM)]
        public uint AdapterRAM {get;set;}

        [WMI(WMIVideoControllerProperties.AdapterCompatibility)]
        public string AdapterCompatibility {get;set;}

        [WMI(WMIVideoControllerProperties.MaxRefreshRate)]
        public uint MaxRefreshRate {get;set;}
    }
}
