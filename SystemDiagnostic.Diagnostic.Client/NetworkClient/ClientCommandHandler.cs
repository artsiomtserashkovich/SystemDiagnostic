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
            return "Test Command";
        }

        [CRCommandHandler("GetComputerComponent")]
        public string GetComputerComponentCommandHandle(ClientCommandRequest clientCommandRequest)
        {
            HardwareSystemInformationController hardwareSystemInformationController 
                =(HardwareSystemInformationController)_serviceProvider.GetService(typeof(HardwareSystemInformationController));
            ComputerHardwareInformationDTO chInformation = hardwareSystemInformationController
                .GetComputerHardwareInformation();
            return JsonConvert.SerializeObject(chInformation);            
        }

        [CRCommandHandler("GetTopPerfomanceProcesses")]
        public string GetTopPerfomanceProcessses(ClientCommandRequest clientCommandRequest){
            OperatingSystemMonitoringController operatingSystemMonitoringController
                =(OperatingSystemMonitoringController)_serviceProvider.GetService(typeof(OperatingSystemInformationController));
            IEnumerable<ProcessPerfomanceDTO> processPerfomanceDTO= operatingSystemMonitoringController.GetTopCPUUsageProcesses();
            return JsonConvert.SerializeObject(processPerfomanceDTO);
        }

        [CRCommandHandler("GetProcessInformationById")]
        public string GetProcessInformationById(ClientCommandRequest clientCommandRequest){
            OperatingSystemInformationController operatingSystemInformationController =
                (OperatingSystemInformationController) _serviceProvider.GetService(typeof(OperatingSystemInformationController));
            ProcessInformationDTO processDTO = operatingSystemInformationController
                .GetProcessInformationById(int.Parse(clientCommandRequest.Arguments));
            return JsonConvert.SerializeObject(processDTO);
        }  

        [CRCommandHandler("GetProcessInformationByName")]
        public string GetProcessInformationByName(ClientCommandRequest clientCommandRequest){
            OperatingSystemInformationController operatingSystemInformationController =
                (OperatingSystemInformationController) _serviceProvider.GetService(typeof(OperatingSystemInformationController));
            ProcessInformationDTO processDTO = operatingSystemInformationController
                .GetProcessInformationByName(clientCommandRequest.Arguments);
            return JsonConvert.SerializeObject(processDTO);
        }


    }
}
