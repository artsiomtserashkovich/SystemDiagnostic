using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    internal class WMIPerfDataProcessQuery : WMIBaseQuery
    {
        public WMIPerfDataProcessQuery(string condition = null, Type entity = null) 
            : base("Win32_PerfFormattedData_PerfProc_Process", condition, entity){ }
    }
}
