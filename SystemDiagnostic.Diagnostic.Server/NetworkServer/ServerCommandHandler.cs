using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Attributes;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.CRServer;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Controllers;

namespace SystemDiagnostic.Diagnostic.Server.NetworkServer
{
    public class ServerCommandHandler : BaseServerCommandHandler
    {
        private IServiceProvider _serviceProvider;
        public ServerCommandHandler(IServiceProvider serviceProvider)
            : base(typeof(ServerCommandHandler))
        {
            _serviceProvider = serviceProvider;
        }

        [CRCommandHandler("Test")]
        public ServerResponseInformation TestHandleMethod(ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
                .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;
            TestController testController = (TestController)_serviceProvider
                .GetService(typeof(TestController));
            return testController.RecieveTest(clientCommand);            
        }

        [CRCommandHandler("GetComputerSystemInformation")]
        public ServerResponseInformation GetComputerSystemInformation
           (ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
                .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;

            ComputerSystemDTO computerSystem = JsonConvert
                .DeserializeObject<ComputerSystemDTO>(clientCommand.SerializedData);
            ComputerController processesController = (ComputerController)_serviceProvider
                .GetService(typeof(ComputerController));
            return processesController.RecieveComputerSystemInformation(computerSystem, clientCommand.ClientLogin);
        }

        [CRCommandHandler("GetComputerComponent")]
        public ServerResponseInformation GetComputerComponent
            (ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
                .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;

            ComputerHardwareInformationDTO chInformation = JsonConvert
                .DeserializeObject<ComputerHardwareInformationDTO>(clientCommand.SerializedData);
            ComputerController computerController = (ComputerController)_serviceProvider
                .GetService(typeof(ComputerController));
            return computerController.RecieveComputerHardwareInformation(chInformation,clientCommand.ClientLogin);
        }

        [CRCommandHandler("GetTopCPUUsageProcessesPerfomance")]
        public ServerResponseInformation GetTopCPUUsageProcessesPerfomance
            (ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
                .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;

            IEnumerable<ProcessPerfomanceDTO>  processesPerfomance 
                = JsonConvert.DeserializeObject<IEnumerable<ProcessPerfomanceDTO>>
                    (clientCommand.SerializedData);
            ProcessesController processesController = (ProcessesController)_serviceProvider
                .GetService(typeof(ProcessesController));
            return processesController.RecieveProcessesPerfomance(processesPerfomance,clientCommand.ClientLogin);           
        }

        [CRCommandHandler("GetTopMemoryUsageProcessesPerfomance")]
        public ServerResponseInformation GetTopMemoryUsageProcessesPerfomance
            (ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
                .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;

            IEnumerable<ProcessPerfomanceDTO> processesPerfomance
                = JsonConvert.DeserializeObject<IEnumerable<ProcessPerfomanceDTO>>
                    (clientCommand.SerializedData);
            ProcessesController processesController = (ProcessesController)_serviceProvider
                .GetService(typeof(ProcessesController));
            return processesController.RecieveProcessesPerfomance(processesPerfomance,clientCommand.ClientLogin);

        }       

        [CRCommandHandler("GetTopCPUUsageProcesses")]
        public ServerResponseInformation GetTopCPUUsageProcesses
            (ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
                .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;

            IEnumerable<ProcessDTO> processes = JsonConvert
                .DeserializeObject<IEnumerable<ProcessDTO>>(clientCommand.SerializedData);
            ProcessesController processesController = (ProcessesController)_serviceProvider
                .GetService(typeof(ProcessesController));
            return processesController.RecieveProcesses(processes,clientCommand.ClientLogin);
        }

        [CRCommandHandler("GetTopMemoryUsageProcesses")]
        public ServerResponseInformation GetTopMemoryUsageProcesses
            (ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
                .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;

            IEnumerable<ProcessDTO> processes = JsonConvert
                .DeserializeObject<IEnumerable<ProcessDTO>>(clientCommand.SerializedData);
            ProcessesController processesController = (ProcessesController)_serviceProvider
                .GetService(typeof(ProcessesController));
            return processesController.RecieveProcesses(processes,clientCommand.ClientLogin);
        }

        [CRCommandHandler("GetProcessInformationById")]
        public ServerResponseInformation GetProcessInformationById
            (ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
               .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;

            ProcessInformationDTO processInformationDTO = JsonConvert
               .DeserializeObject<ProcessInformationDTO>(clientCommand.SerializedData);
            ProcessesController processesController = (ProcessesController)_serviceProvider
               .GetService(typeof(ProcessesController));
            return processesController.RecieveProcessInformation(processInformationDTO,clientCommand.ClientLogin);
        }

        [CRCommandHandler("GetProcessInformationByName")]
        public ServerResponseInformation GetProcessInformationByName
            (ClientCommandInformation clientCommand)
        {
            AuthorizeController authorizeController = (AuthorizeController)_serviceProvider
               .GetService(typeof(AuthorizeController));
            var resAuthorize = authorizeController.Authorize(clientCommand.ClientLogin);
            if (resAuthorize != null)
                return resAuthorize;

            ProcessInformationDTO processInformationDTO = JsonConvert
                .DeserializeObject<ProcessInformationDTO>(clientCommand.SerializedData);
            ProcessesController processesController = (ProcessesController)_serviceProvider
               .GetService(typeof(ProcessesController));
            return processesController.RecieveProcessInformation(processInformationDTO,clientCommand.ClientLogin);
        }
    }
}
