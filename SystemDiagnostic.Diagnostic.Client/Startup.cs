using System;
using System.Collections.Generic;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Managers;

namespace SystemDiagnostic.Diagnostic.Client
{
    public class Startup
    {
        public static void Main()
        {
            using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher())
            {
                IWMIPhysicalMemoryManager wMIPhysicalMemoryManager = new WMIPhysicalMemoryManager(managementObjectSearcher);
                IEnumerable<WMIPhysicalMemory> physicalMemories = wMIPhysicalMemoryManager.Get();
            }
        }
    }
}
