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
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Interfaces;
using SystemDiagnostic.Diagnostic.Client.NetworkClient;
using System;
using SystemDiagnostic.Diagnostic.Client.Controllers;

namespace SystemDiagnostic.Diagnostic.Client
{
    public class Startup
    {
        public static void Main()
        {
            IServiceCollection service = new ServiceCollection();
            ConfigureServices(service);
            IServiceProvider serviceProvider = service.BuildServiceProvider();
            IScheduleCommandManager scheduleCommandManager = new ScheduleCommandManager();
            ConfigureScheduleManager(scheduleCommandManager);
            IClientResponseHandler clientResponseHandler = new ClientResponseHandler();
            IClientCommandHandler clientCommandHandler = new ClientCommandHandler(serviceProvider);
            IUserInterface userInterface = new UserInterface();
            IClient client = new CommandResponseProtocol.CRClient.Client(clientCommandHandler,
                clientResponseHandler, scheduleCommandManager, userInterface);
            client.Start();
        }

        private static void ConfigureScheduleManager(IScheduleCommandManager scheduleCommandManager)
        {
            scheduleCommandManager.AddTimer(new ClientCommandRequest { Command = "GetComputerSystemInformation" }, 5, false);
            scheduleCommandManager.AddTimer(new ClientCommandRequest { Command = "GetComputerComponent" }, 10, false);
            scheduleCommandManager.AddTimer(new ClientCommandRequest { Command = "GetTopMemoryUsageProcesses" }, 90, true);
            scheduleCommandManager.AddTimer(new ClientCommandRequest { Command = "GetTopCPUUsageProcesses" }, 60, true);
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
                .AddTransient<ProcessInformationService>()
                .AddTransient<ProcessPerfomanceService>()
                .AddTransient<ComputerSystemInformationService>()
                .AddTransient<HardwareSystemInformationController>()
                .AddTransient<OperatingSystemInformationController>()
                .AddTransient<OperatingSystemMonitoringController>()
                .AddAutoMapper();
        }
    }
}
