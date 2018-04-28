using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    internal class WMIComputerSystemQuery : WMIBaseQuery
    {
        public WMIComputerSystemQuery(string condition = null, Type entity = null) 
            : base("WIN32_ComputerSystem", condition, entity){} 
    }
}
