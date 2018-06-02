using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Entities
{
    public class WMIComputerSystem
    {
        [WMI(WMIComputerSystemProperties.DNSHostName)]
        public string DNSHostName {get;set;}
        
        [WMI(WMIComputerSystemProperties.Name)]
        public string Name {get;set;}        

        [WMI(WMIComputerSystemProperties.UserName)]
        public string UserName{get;set;}        
    }
}
