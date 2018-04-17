using System;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    internal class WMIDiskDriveQuery : WMIBaseQuery
    {
        public WMIDiskDriveQuery(string condition = null, Type entity = null) 
            : base("WIN32_DiskDrive", condition, entity){ }
    }
}
