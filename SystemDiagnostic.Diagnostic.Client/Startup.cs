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
            using(IClient client = new TCPClient(ip,1300)){
                ProcessService processService = provider.GetService<ProcessService>();
                IEnumerable<WMIProcess> processes = processService.GetProcesses().OrderBy(t => t.Id);
                VideoCardService videoCardService = provider.GetService<VideoCardService>();
                IEnumerable<VideoCardDTO> videoCards = videoCardService.GetVideoCards();
                ProcessorService processorService = provider.GetService<ProcessorService>();
                ProcessorDTO processorDTO = processorService.GetProcessor();
                PhysicalMemoryService physicalMemoryService = provider.GetService<PhysicalMemoryService>();
                IEnumerable<PhysicalMemoryDTO> phisicalMemoriesDTo = physicalMemoryService.GetPhysicalMemories();
                DiskDriveService diskDriveService = provider.GetService<DiskDriveService>();
                IEnumerable<DiskDriveDTO> diskDrives = diskDriveService.GetDiskDrives();
                MotherBoardService motherBoardService = provider.GetService<MotherBoardService>();
                MotherBoardDTO motherBoardDTO = motherBoardService.GetBaseBoard();
            }

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
