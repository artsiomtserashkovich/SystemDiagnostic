using System;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIComputerSystemManager : WMIBaseManager, IWMIComputerSystemManager
    {
        public WMIComputerSystemManager(ManagementObjectSearcher managementObjectSearcher) 
            : base(managementObjectSearcher){ }

        public WMIComputerSystem GetComputerSystem()
        {
            throw new NotImplementedException();
        }
    }
}
