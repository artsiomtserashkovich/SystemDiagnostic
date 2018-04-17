using System;
using System.Collections.Generic;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIDiskDriveManager : WMIBaseManager, IWMIDiskDriveManager
    {
        public WMIDiskDriveManager(ManagementObjectSearcher managementObjectSearcher)
            : base(managementObjectSearcher) { }

        public IEnumerable<WMIDiskDrive> Get()
        {
            IList<WMIDiskDrive> diskDrives = new List<WMIDiskDrive>();
            ManagementObjectCollection managementObjectCollection
                = Execute(new WMIDiskDriveQuery(condition: "MediaType= 'Fixed hard disk media'",
                    entity: typeof(WMIDiskDrive)));
            foreach (ManagementBaseObject managementObject in managementObjectCollection)
            {
                diskDrives.Add(WMIMapper<WMIDiskDrive>.Extract(managementObject));
            }
            return diskDrives;
        }
    }
}
