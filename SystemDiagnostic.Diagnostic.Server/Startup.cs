using System;
using System.Net;
using Microsoft.Extensions.DependencyInjection;

namespace SystemDiagnostic.Diagnostic.Server
{
    class Program
    {   public static void Main()
        {
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);           
        }

        private static void ConfigureServices(IServiceCollection service)
        {
        
        }   
    }
}
