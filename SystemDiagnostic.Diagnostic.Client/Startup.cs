using System.Collections.Generic;
using System.Management;
using System.Net;
using AutoMapper;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using SystemDiagnostic.Diagnostic.Client.Services;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.Client.WMI.Managers;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.DTO.CommandHandlerEntities;

namespace SystemDiagnostic.Diagnostic.Client
{
    public class Startup
    {
        public static void Main()
        {
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
          
        }

        private static void ConfigureServices(IServiceCollection service)
        {
            service.AddTransient<ManagementObjectSearcher>()
                .AddTransient<IWMIManagers, WMIManagers>()  
                .AddTransient<ProcessorService>()     
                .AddTransient<DiskDriveService>()
                .AddTransient<MotherBoardService>()
                .AddTransient<PhysicalMemoryService>()  
                .AddTransient<VideoCardService>()       
                .AddTransient<ProcessService>()                
                .AddAutoMapper();
        }   
    }
}
