using System;
using System.Collections.Generic;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    internal class WMIVideoControllerManager : WMIBaseManager, IWMIVideoControllerManager
    {
        public WMIVideoControllerManager(ManagementObjectSearcher managementObjectSearcher) 
            : base(managementObjectSearcher){ }

        public IEnumerable<WMIVideoController> GetWMIVideoControllers()
        {
            IList<WMIVideoController> videoControllers = new List<WMIVideoController>();
            ManagementObjectCollection managementObjectCollection 
                = Execute(new WMIVideoControllerQuery());
            foreach(ManagementBaseObject ManagementBaseObject in managementObjectCollection){
                videoControllers.Add(WMIMapper<WMIVideoController>.Extract(ManagementBaseObject));
            }
            return videoControllers;
        }
    }
}
