using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIProcessManager : WMIBaseManager , IWMIProcessManager
    {
        public WMIProcessManager(ManagementObjectSearcher managementObjectSearcher) 
            : base(managementObjectSearcher) { }
        
        public IEnumerable<WMIProcess> GetWMIProcesses(){
            IList<WMIProcess> wmiProcesses = new List<WMIProcess>();
            ManagementObjectCollection managementObjectCollection 
                = Execute(new WMIProcessQuery());
            foreach(ManagementBaseObject managementBaseObject in managementObjectCollection)
                wmiProcesses.Add(WMIMapper<WMIProcess>.Extract(managementBaseObject));            
            return wmiProcesses;
        }      

        public WMIProcess GetWMIProcessById(int id)
        {
            ManagementBaseObject result 
                = Execute(new WMIProcessQuery(condition: $"ProcessId = '{id}'" ,
                    entity: typeof(WMIProcess))).Cast<ManagementBaseObject>()
                    .FirstOrDefault();
            return result == null? null : WMIMapper<WMIProcess>.Extract(result);
        }

        public WMIProcess GetWMIProcessByName(string name)
        {
            ManagementBaseObject result 
                = Execute(new WMIProcessQuery(condition: $"Name = '{name}'" ,
                    entity: typeof(WMIProcess))).Cast<ManagementBaseObject>()
                    .FirstOrDefault();
            return result == null? null : WMIMapper<WMIProcess>.Extract(result);
        }
    }
}
