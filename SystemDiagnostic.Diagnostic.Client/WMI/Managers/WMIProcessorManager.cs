using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    class WMIProcessorManager : WMIBaseManager,IWMIProcessorManager
    {   
        public WMIProcessorManager(ManagementObjectSearcher managementObjectSearcher) 
            : base(managementObjectSearcher) { }

        public WMIProcessor Get(){
            ManagementBaseObject result = Execute(new WMIProcessorQuery(entity:typeof(WMIProcessor)))
            .Cast<ManagementBaseObject>().FirstOrDefault();
            return result == null? null :WMIMapper<WMIProcessor>.Extract(result);
        }
    }
}
