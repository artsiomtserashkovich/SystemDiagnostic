using System;
using SystemDiagnostic.Diagnostic.Client.Services;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Controllers
{
    public class OperatingSystemInformationController
    {
        private ComputerSystemInformationService _computerSystemService;
        private ProcessService _processService;
        public OperatingSystemInformationController(
            ComputerSystemInformationService computerSystemService,
            ProcessService processService
        )
        {
            _computerSystemService = computerSystemService;
            _processService = processService;
        }

        public ComputerOperatingInformationDTO GetComputerOperatingInformation(){
            return new ComputerOperatingInformationDTO{
                ComputerInformation = _computerSystemService.GetComputerSystemInformation(),
                CurrentProcesses = _processService.GetAllProcesses()
            };
        }
    }
}
