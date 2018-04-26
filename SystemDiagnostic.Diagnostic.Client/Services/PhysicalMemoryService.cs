using System;
using System.Collections.Generic;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class PhysicalMemoryService
    {
        private readonly IMapper _mapper;
        private readonly IWMIManagers _wmiManagers;

        public PhysicalMemoryService(IWMIManagers wmiManagers,IMapper mapper){
            _mapper = mapper;
            _wmiManagers = wmiManagers;
        }

        public IEnumerable<PhysicalMemoryDTO> GetPhysicalMemories(){
            IEnumerable<WMIPhysicalMemory> wmiPhysicalMemories = _wmiManagers.WMIPhysicalMemoryManager.Get();
            return _mapper.Map<IEnumerable<WMIPhysicalMemory>,IEnumerable<PhysicalMemoryDTO>>(wmiPhysicalMemories);            
        }
    }
}
