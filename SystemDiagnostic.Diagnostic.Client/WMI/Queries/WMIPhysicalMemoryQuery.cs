using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    internal class WMIPhysicalMemoryQuery : WMIBaseQuery
    {
        public WMIPhysicalMemoryQuery(string condition = null, Type entity = null)
            : base("WIN32_PhysicalMemory", condition, entity) { }
    }
}
