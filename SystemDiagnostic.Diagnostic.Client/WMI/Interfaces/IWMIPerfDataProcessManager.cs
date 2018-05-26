using System;
using System.Collections.Generic;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Interfaces
{
    public interface IWMIPerfDataProcessManager
    {
        IEnumerable<WMIPerfDataProcess> GetWMIPerfDataProcesses();
        WMIPerfDataProcess GetWMIPerfDataProcessById(int id);
        WMIPerfDataProcess GetWMIPerfDataProcessByName(string name);
    }
}
