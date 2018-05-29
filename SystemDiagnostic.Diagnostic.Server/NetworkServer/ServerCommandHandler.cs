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
            return testController.Test(clientCommand);            
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
            Console.WriteLine(DateTime.Now.ToString());
            Console.WriteLine(chInformation.ToString());
            return new ServerResponseInformation
            {
                Status = 1,
                SerializedData = "Success"
            };
        }

        [CRCommandHandler("GetTopPerfomanceProcesses")]
        public ServerResponseInformation GetTopPerfomanceProcesses
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
            Console.WriteLine(DateTime.Now.ToString());
            foreach (ProcessPerfomanceDTO process in processesPerfomance)
                Console.WriteLine(process.ProcessId + " " + process.Name + " " 
                    + process.PercentCPUUsage + " " + process.RamMemoryUsageMB);
            return new ServerResponseInformation
            {
                Status = 1,
                SerializedData = "Success"
            };
        }        
    }
}
