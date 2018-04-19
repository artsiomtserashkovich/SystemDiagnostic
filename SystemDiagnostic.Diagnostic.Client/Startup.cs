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
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            service.

        }

        private static void ConfigureServices(IServiceCollection service)
        {
            service.AddTransient<ManagementObjectSearcher>()
                .AddTransient<IWMIManagers, WMIManagers>();
        }
    }
}
