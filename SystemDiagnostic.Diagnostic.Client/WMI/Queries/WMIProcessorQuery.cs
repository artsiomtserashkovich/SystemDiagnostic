using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    class WMIProcessorQuery : WMIBaseQuery
    {
        public WMIProcessorQuery(string condition = null, Type entity = null)
            : base("WIN32_Processor", condition, entity) { }
    }
}
