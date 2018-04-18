using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Interfaces
{
    public interface IWMIManagers
    {
        IWMIBaseBoardManager WMIBaseBoardManager{get;}
        IWMIDiskDriveManager DiskDriveManager {get;}
        IWMIPhysicalMemoryManager WMIPhysicalMemoryManager {get;}
        IWMIProcessorManager WMIProcessorManager {get;}
        IWMIVideoControllerManager WMIVideoController {get;}
    }
}
