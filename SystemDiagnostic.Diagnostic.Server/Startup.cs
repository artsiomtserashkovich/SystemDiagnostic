using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
using SystemDiagnostic.Diagnostic.Server.NetworkServer;

namespace SystemDiagnostic.Diagnostic.Server
{
    class Program
    {   public static void Main()
        {
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            IServiceProvider serviceProvider = service.BuildServiceProvider();
            IPAddress ip = IPAddress.Parse("127.0.0.1");
            NetworkServer.NetworkServer server = new NetworkServer.NetworkServer(ip,1045,serviceProvider);
            server.Start(30);
        }

        private static void ConfigureServices(IServiceCollection service)
        {
        
        }   
    }
}
