using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    internal class WMIProcessQuery : WMIBaseQuery
    {
        public WMIProcessQuery(string condition = null, Type entity = null)
         : base("WIN32_Process", condition, entity){ }
    }
}
