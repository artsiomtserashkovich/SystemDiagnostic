using System.Management;
using Microsoft.Extensions.DependencyInjection;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Managers;

namespace SystemDiagnostic.Diagnostic.Client
{
    public class Startup
    {
        public static void Main()
        {
            var service = new ServiceCollection();
            service.AddTransient<ManagementObjectSearcher>()
                .AddTransient<IWMIManagers,WMIManagers>()
                .BuildServiceProvider();
            
    
        }
    }
}
