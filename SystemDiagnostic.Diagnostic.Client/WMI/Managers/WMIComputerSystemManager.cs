using System;
using System.Linq;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIComputerSystemManager : WMIBaseManager, IWMIComputerSystemManager
    {
        public WMIComputerSystemManager(ManagementObjectSearcher managementObjectSearcher) 
            : base(managementObjectSearcher){ }

        public WMIComputerSystem GetComputerSystemInformation()
        {
            ManagementBaseObject result = Execute(new WMIComputerSystemQuery(entity: typeof(WMIComputerSystem)))
                .Cast<ManagementBaseObject>().FirstOrDefault();
            return result == null? null : WMIMapper<WMIComputerSystem>.Extract(result);
        }
    }
}
