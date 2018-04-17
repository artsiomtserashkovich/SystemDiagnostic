using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Entities
{
    public class WMIBaseBoard
    {
        [WMI(WMIBaseBoardProperties.SerialNumber)]
        public string Id {get;set;}

        [WMI(WMIBaseBoardProperties.Manufacturer)]
        public string Manufacturer {get;set;}

        [WMI(WMIBaseBoardProperties.Product)]
        public string Product {get;set;}

    }
}
