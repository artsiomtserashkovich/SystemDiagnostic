using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes;
using SystemDiagnostic.Diagnostic.Client.WMI.Attributes.Properties;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Entities
{
    public class WMIDiskDrive
    {
        [WMI(WMIDiskDriveProperties.SerialNumber)]
        public string Id { get; set; }

        [WMI(WMIDiskDriveProperties.Model)]
        public string Model { get; set; }

        [WMI(WMIDiskDriveProperties.Size)]
        public ulong Size { get; set; }

        [WMI(WMIDiskDriveProperties.MediaType)]
        public string MediaType { get; set; }

    }
}
