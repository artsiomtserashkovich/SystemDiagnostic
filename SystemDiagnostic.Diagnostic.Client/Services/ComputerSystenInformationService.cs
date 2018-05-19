using System;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class ComputerSystemInformationService
    {
        private readonly IMapper _mapper;
        private readonly IWMIManagers _wmimanagers;

        public ComputerSystemInformationService(IMapper mapper,IWMIManagers wmimanagers){
            _mapper = mapper;
            _wmimanagers = wmimanagers;
        }

        public ComputerSystemDTO GetComputerSystemInformation(){
            WMIComputerSystem wmiComputerSystem = _wmimanagers
                .WMIComputerSystemManager.GetComputerSystemInformation();
            return _mapper.Map<WMIComputerSystem,ComputerSystemDTO>(wmiComputerSystem);
        }
    }
}
