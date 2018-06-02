using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.CommandResponseProtocol.Entities;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Exceptions;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;

namespace SystemDiagnostic.Diagnostic.Server.Controllers
{
    class ComputerController
    {
        private readonly IComputerComponentService _computerComponentService;
        private readonly IComputerSystemService _computerSystemService;
        private readonly IProcessService _processService;

        public ComputerController(
            IComputerComponentService computerComponentService,
            IComputerSystemService computerSystemService,
            IProcessService processService
            )
        {
            _computerComponentService = computerComponentService;
            _processService = processService;
            _computerSystemService = computerSystemService;
        }

        public ServerResponseInformation RecieveComputerHardwareInformation
            (ComputerHardwareInformationDTO computeHardwareInformation, ClientLoginModel clientLogin)
        {
            try
            {
                _computerComponentService.UpdateProcessor
                    (clientLogin.Login, computeHardwareInformation.Processor);
                _computerComponentService.UpdateMotherBoard
                    (clientLogin.Login, computeHardwareInformation.MotherBoard);
                _computerComponentService.UpdateVideoCards
                    (clientLogin.Login, computeHardwareInformation.VideoCards);
                _computerComponentService.UpdateDiskDrives
                    (clientLogin.Login, computeHardwareInformation.DiskDrives);
                _computerComponentService.UpdatePhysicalMemories
                    (clientLogin.Login, computeHardwareInformation.PhysicalMemories);
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

        public ServerResponseInformation RecieveComputerSystemInformation
            (ComputerSystemDTO computerSystem,ClientLoginModel clientLogin)
        {
            try
            {
                _computerSystemService.UpdateComputerSystem(clientLogin.Login,computerSystem);
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

        public ServerResponseInformation RecieveComputerOperatingInformation
            (ComputerOperatingInformationDTO computerOperatingInformation, ClientLoginModel clientLogin)
        {
            try
            {
                _computerSystemService.UpdateComputerSystem(clientLogin.Login, computerOperatingInformation.ComputerInformation);
                _processService.UpdateProcesses(clientLogin.Login, computerOperatingInformation.CurrentProcesses);
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
