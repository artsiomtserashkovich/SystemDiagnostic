using System;
using System.Management;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Queries
{
    abstract class WMIBaseQuery
    {
        private readonly SelectQuery _selectQuery;
        protected WMIBaseQuery(string className, string condition = null, string[] Properties = null)
        {
            _selectQuery = new SelectQuery(className, condition, Properties);
        }
        public SelectQuery SelectQuery => _selectQuery;
    }
}
