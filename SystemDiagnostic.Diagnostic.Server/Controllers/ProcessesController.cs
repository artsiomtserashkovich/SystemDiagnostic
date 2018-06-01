using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;
using SystemDiagnostic.Diagnostic.Server.Services.Exceptions;

namespace SystemDiagnostic.Diagnostic.Server.Controllers
{
    class ProcessesController
    {

        private readonly IProcessService _processService;

        public ProcessesController(IProcessService processService)
        {
            _processService = processService;
        }

        public ServerResponseInformation RecieveProcessesPerfomance
            (IEnumerable<ProcessPerfomanceDTO> processesPerfomance, ClientLoginModel clientLogin)
        {
            try
            {
                _processService.AddProcessesPerfomance(clientLogin.Login, processesPerfomance);
                return new ServerResponseInformation
                {
                    Status = 1,
                    SerializedData = "Success"
                };
            }
            catch (ServerServicesException exception)
            {
                return new ServerResponseInformation
                {
                    Status = -1,
                    SerializedData = exception.Message
                };
            }
        }

        public ServerResponseInformation RecieveProcessInformation
            (ProcessInformationDTO processInformation, ClientLoginModel clientLogin)
        {
            try
            {
                _processService.UpdateProcessInformation(clientLogin.Login, processInformation);
                return new ServerResponseInformation
                {
                    Status = 1,
                    SerializedData = "Success"
                };
            }
            catch (ServerServicesException exception)
            {
                return new ServerResponseInformation
                {
                    Status = -1,
                    SerializedData = exception.Message
                };
            }
        }

        public ServerResponseInformation RecieveProcesses
            (IEnumerable<ProcessDTO> processes, ClientLoginModel clientLogin)
        {
            try
            {
                _processService.UpdateProcesses(clientLogin.Login, processes);
                return new ServerResponseInformation
                {
                    Status = 1,
                    SerializedData = "Success"
                };
            }
            catch (ServerServicesException exception)
            {
                return new ServerResponseInformation
                {
                    Status = -1,
                    SerializedData = exception.Message
                };
            }
        }
    }
}
