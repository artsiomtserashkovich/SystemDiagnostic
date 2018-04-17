using System;
using System.Collections.Generic;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIPhysicalMemoryManager : WMIBaseManager, IWMIPhysicalMemoryManager
    {
        public WMIPhysicalMemoryManager(ManagementObjectSearcher managementObjectSearcher)
            : base(managementObjectSearcher) { }

        public IEnumerable<WMIPhysicalMemory> Get()
        {
            IList<WMIPhysicalMemory> physicalMemories = new List<WMIPhysicalMemory>();
            ManagementObjectCollection managementObjectCollection
                = Execute(new WMIPhysicalMemoryQuery(entity: typeof(WMIPhysicalMemory)));
            foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
            {
                physicalMemories.Add(WMIMapper<WMIPhysicalMemory>.Extract(managementBaseObject));
            }
            return physicalMemories;
        }
    }
}
