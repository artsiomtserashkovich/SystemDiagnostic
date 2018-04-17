using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    internal class WMIBaseBoardQuery : WMIBaseQuery
    {
        public WMIBaseBoardQuery(string condition = null, Type entity = null) 
        : base("WIN32_BaseBoard", condition, entity){ }
    }
}
