using System;
using System.Linq;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIBaseBoardManager : WMIBaseManager, IWMIBaseBoardManager
    {
        public WMIBaseBoardManager(ManagementObjectSearcher managementObjectSearcher)
        : base(managementObjectSearcher) { }

        public WMIBaseBoard GetWMIBaseBoard()
        {
            ManagementBaseObject result = Execute(new WMIBaseBoardQuery(entity: typeof(WMIBaseBoard)))
            .Cast<ManagementBaseObject>().FirstOrDefault();
            return result == null ? null : WMIMapper<WMIBaseBoard>.Extract(result);
        }
    }
}
