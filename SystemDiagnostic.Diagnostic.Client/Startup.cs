using System;
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
                IWMIBaseBoardManager _baseBoardManager = new WMIBaseBoardManager(managementObjectSearcher);
                var result = _baseBoardManager.Get();
                Console.WriteLine();
            }
        }
    }
}
