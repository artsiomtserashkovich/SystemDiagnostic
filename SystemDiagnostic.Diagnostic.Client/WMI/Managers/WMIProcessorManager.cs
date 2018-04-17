using System;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    class WMIProcessorManager : WMIBaseManager
    {   
        public WMIProcessorManager(ManagementObjectSearcher managementObjectSearcher) 
            : base(managementObjectSearcher) { }

        public WMIProcessor Get(){

        }
    }
}
