using System;
using System.Collections.Generic;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIPerfDataProcessManager : WMIBaseManager, IWMIPerfDataProcessManager
    {
        public WMIPerfDataProcessManager(ManagementObjectSearcher managementObjectSearcher)
             : base(managementObjectSearcher){ }

        public WMIPerfDataProcess GetWMIPerfDataProcessById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<WMIPerfDataProcess> GetWMIPerfDataProcesses()
        {
            throw new NotImplementedException();
        }
    }
}
