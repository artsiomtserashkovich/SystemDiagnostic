using System.Management;
using System.Net;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Managers;
using SystemDiagnostic.Diagnostic.TCPProtocol.Client;
using SystemDiagnostic.Diagnostic.TCPProtocol.Interfaces;

namespace SystemDiagnostic.Diagnostic.Client
{
    public class Startup
    {
        public static void Main()
        {
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);

            ServiceProvider provider = service.BuildServiceProvider();

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IClient client = new TCPClient(ip,1300);

        }

        private static void ConfigureServices(IServiceCollection service)
        {
            service.AddTransient<ManagementObjectSearcher>()
                .AddTransient<IWMIManagers, WMIManagers>()  
                .AddTransient<IClient,TCPClient>()
                .AddAutoMapper();
        }   
    }
}
