using System.Management;
using SystemDiagnostic.Diagnostic.Client.WMI.Queries;

namespace SystemDiagnostic.Diagnostic.Client.WMI.Managers
{    abstract class WMIBaseManager
    {
        protected readonly ManagementObjectSearcher _managementObjectSearcher;

        protected WMIBaseManager(ManagementObjectSearcher managementObjectSearcher)
        {
            _managementObjectSearcher = managementObjectSearcher;
        }

        protected ManagementObjectCollection Execute(WMIBaseQuery query)
        {
            _managementObjectSearcher.Query = query.SelectQuery;
            return _managementObjectSearcher.Get();
        }
    }
}
