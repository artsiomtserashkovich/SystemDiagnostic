using System;
using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{
    public class WMIManagers : IWMIManagers , IDisposable
    {
        private readonly ManagementObjectSearcher _managementObjectSearcher;
        public WMIManagers(ManagementObjectSearcher managementObjectSearcher){
            _managementObjectSearcher = managementObjectSearcher;
            WMIPerfDataProcessManager = new WMIPerfDataProcessManager(_managementObjectSearcher);
            WMIBaseBoardManager = new WMIBaseBoardManager(_managementObjectSearcher);
            WMIDiskDriveManager = new WMIDiskDriveManager(_managementObjectSearcher);
            WMIPhysicalMemoryManager = new WMIPhysicalMemoryManager(_managementObjectSearcher);
            WMIProcessorManager = new WMIProcessorManager(_managementObjectSearcher);
            WMIVideoController = new WMIVideoControllerManager(_managementObjectSearcher);
            WMIProcessManager = new WMIProcessManager(_managementObjectSearcher);
            WMIComputerSystemManager = new WMIComputerSystemManager(_managementObjectSearcher);
        }
        public IWMIBaseBoardManager WMIBaseBoardManager {get;}

        public IWMIDiskDriveManager WMIDiskDriveManager {get;}

        public IWMIPhysicalMemoryManager WMIPhysicalMemoryManager {get;}

        public IWMIProcessorManager WMIProcessorManager {get;}

        public IWMIVideoControllerManager WMIVideoController {get;}

        public IWMIProcessManager WMIProcessManager {get;}

        public IWMIPerfDataProcessManager WMIPerfDataProcessManager {get;}

        public IWMIComputerSystemManager WMIComputerSystemManager {get;}

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _managementObjectSearcher.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
