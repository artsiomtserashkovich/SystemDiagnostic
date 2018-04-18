using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    internal class WMIVideoControllerQuery : WMIBaseQuery
    {
        public WMIVideoControllerQuery(string condition = null, Type entity = null) 
            : base("WIN32_VideoController", condition, entity){ }
    }
}
