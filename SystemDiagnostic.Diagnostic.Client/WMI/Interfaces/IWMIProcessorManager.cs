using System;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Interfaces
{
    public interface IWMIProcessorManager
    {
        WMIProcessor Get();
    }
}