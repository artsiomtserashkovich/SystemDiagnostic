using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIPerfDataProcessManager : WMIBaseManager, IWMIPerfDataProcessManager
    {
        public WMIPerfDataProcessManager(ManagementObjectSearcher managementObjectSearcher)
             : base(managementObjectSearcher){ }

        public WMIPerfDataProcess GetWMIPerfDataProcessById(int id)
        {
            ManagementBaseObject managementBaseObject = Execute(new WMIPerfDataProcessQuery
                ($"IDProcess = {id}",typeof(WMIPerfDataProcess)))
                .Cast<ManagementBaseObject>().FirstOrDefault(); 
            return managementBaseObject != null? WMIMapper<WMIPerfDataProcess>
                .Extract(managementBaseObject) : null;
        }

        public WMIPerfDataProcess GetWMIPerfDataProcessByName(string name)
        {
             ManagementBaseObject managementBaseObject = Execute(new WMIPerfDataProcessQuery
                ($"Name = {name}",typeof(WMIPerfDataProcess)))
                .Cast<ManagementBaseObject>().FirstOrDefault(); 
            return managementBaseObject != null? WMIMapper<WMIPerfDataProcess>
                .Extract(managementBaseObject) : null;
        }

        public IEnumerable<WMIPerfDataProcess> GetWMIPerfDataProcesses()
        {
            IList<WMIPerfDataProcess> wmiPerfDataProcesses = new List<WMIPerfDataProcess>();
            ManagementObjectCollection managementObjectCollection
                = Execute(new WMIPerfDataProcessQuery(entity:typeof(WMIPerfDataProcess)));
            foreach(ManagementBaseObject managementObject in managementObjectCollection)
                wmiPerfDataProcesses.Add(WMIMapper<WMIPerfDataProcess>.Extract(managementObject));            
            return wmiPerfDataProcesses;
        }
    }
}
