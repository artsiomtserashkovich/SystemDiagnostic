using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SystemDiagnostic.Diagnostic.Client.Controllers;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRClient.Entities;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.NetworkClient
{
    public class ClientCommandHandler : BaseClientCommandHandler
    {
        private IServiceProvider _serviceProvider;

        public ClientCommandHandler(IServiceProvider serviceProvider)
            : base(typeof(ClientCommandHandler))
        {
            _serviceProvider = serviceProvider;
        }

        [CRCommandHandler("Test")]
        public string TestCommandHandle(ClientCommandRequest clientCommandRequest)
        {
            return "Send Test Command";
        }

        [CRCommandHandler("GetComputerComponent")]
        public string GetComputerComponentCommandHandle(ClientCommandRequest clientCommandRequest)
        {
            HardwareSystemInformationController hardwareSystemInformationController
                = (HardwareSystemInformationController)_serviceProvider.GetService(typeof(HardwareSystemInformationController));
            ComputerHardwareInformationDTO chInformation = hardwareSystemInformationController
                .GetComputerHardwareInformation();
            return JsonConvert.SerializeObject(chInformation);
        }

        [CRCommandHandler("GetTopCPUUsageProcessesPerfomance")]
        public string GetTopCPUUsageProcessesPerfomance(ClientCommandRequest clientCommandRequest)
        {
            OperatingSystemMonitoringController operatingSystemMonitoringController
                = (OperatingSystemMonitoringController)_serviceProvider.GetService(typeof(OperatingSystemMonitoringController));
            IEnumerable<ProcessPerfomanceDTO> processPerfomanceDTO 
                = operatingSystemMonitoringController.GetTopCPUUsageProcessesPerfomance();
            return JsonConvert.SerializeObject(processPerfomanceDTO);
        }
        
        [CRCommandHandler("GetTopMemoryUsageProcessesPerfomance")]
        public string GetTopMemoryUsageProcessesPerfomance(ClientCommandRequest clientCommandRequest)
        {
            OperatingSystemMonitoringController operatingSystemMonitoringController
                = (OperatingSystemMonitoringController)_serviceProvider.GetService(typeof(OperatingSystemMonitoringController));
            IEnumerable<ProcessPerfomanceDTO> processPerfomanceDTO
                = operatingSystemMonitoringController.GetTopMemoryUsageProcessesPerfomance();
            return JsonConvert.SerializeObject(processPerfomanceDTO);
        }

        [CRCommandHandler("GetTopCPUUsageProcesses")]
        public string GetTopCPUUsageProcesses(ClientCommandRequest clientCommandRequest)
        {
            OperatingSystemMonitoringController operatingSystemMonitoringController
                = (OperatingSystemMonitoringController)_serviceProvider.GetService(typeof(OperatingSystemMonitoringController));
            IEnumerable<ProcessDTO> processes = operatingSystemMonitoringController.GetTopCPUUsageProcesses();
            return JsonConvert.SerializeObject(processes);
        }

        [CRCommandHandler("GetTopMemoryUsageProcesses")]
        public string GetMemoryUsageProcesses(ClientCommandRequest clientCommandRequest)
        {
            OperatingSystemMonitoringController operatingSystemMonitoringController
                = (OperatingSystemMonitoringController)_serviceProvider.GetService(typeof(OperatingSystemMonitoringController));
            IEnumerable<ProcessDTO> processes = operatingSystemMonitoringController.GetTopMemoryUsageProcesses();
            return JsonConvert.SerializeObject(processes);
        }

        [CRCommandHandler("GetProcessInformationById")]
        public string GetProcessInformationById(ClientCommandRequest clientCommandRequest)
        {
            OperatingSystemInformationController operatingSystemInformationController =
                (OperatingSystemInformationController)_serviceProvider.GetService(typeof(OperatingSystemInformationController));
            ProcessInformationDTO processDTO = operatingSystemInformationController
                .GetProcessInformationById(int.Parse(clientCommandRequest.Arguments));
            return JsonConvert.SerializeObject(processDTO);
        }

        [CRCommandHandler("GetProcessInformationByName")]
        public string GetProcessInformationByName(ClientCommandRequest clientCommandRequest)
        {
            OperatingSystemInformationController operatingSystemInformationController =
                (OperatingSystemInformationController)_serviceProvider.GetService(typeof(OperatingSystemInformationController));
            ProcessInformationDTO processDTO = operatingSystemInformationController
                .GetProcessInformationByName(clientCommandRequest.Arguments);
            return JsonConvert.SerializeObject(processDTO);
        }


    }
}
