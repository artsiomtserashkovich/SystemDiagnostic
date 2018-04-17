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
                IWMIProcessorManager processorManager = new WMIProcessorManager(managementObjectSearcher);
                WMIProcessor processor = processorManager.Get();
                Console.WriteLine(processor.Id , processor.Name, processor.Socket, processor.NumberOfCores, processor.Description);
            }
        }
    }
}
