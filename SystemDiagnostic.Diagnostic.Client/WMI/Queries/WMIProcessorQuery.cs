using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    class WMIProcessorQuery : WMIBaseQuery
    {
        public WMIProcessorQuery(string className, string condition = null, string[] Properties = null) 
            : base(className, condition, Properties){ }
    }
}
