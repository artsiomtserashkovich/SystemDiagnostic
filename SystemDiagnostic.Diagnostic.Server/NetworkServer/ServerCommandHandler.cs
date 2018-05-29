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
            return computerController.RecieveComputerHardwareInformation(chInformation);
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
            return processesController.RecieveProcessesPerfomance(processesPerfomance);           
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
            return processesController.RecieveProcessesPerfomance(processesPerfomance);

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
            return processesController.RecieveProcesses(processes);
        }

        [CRCommandHandler("GetTopMemoryUsageProcesses")]

        [CRCommandHandler("GetProcessInformationById")]

        [CRCommandHandler("GetProcessInformationByName")]
    }
}
