using System;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class ProcessorService
    {
        private readonly IWMIManagers _wmiManagers;
        private readonly IMapper _mapper;
        public ProcessorService(IWMIManagers wmiManagers,IMapper mapper){
           _wmiManagers = wmiManagers;
           _mapper = mapper;
        }

        public ProcessorDTO GetProcessor(){
            WMIProcessor wmiprocessor = _wmiManagers.WMIProcessorManager.Get();
            ProcessorDTO processor = _mapper.Map<WMIProcessor,ProcessorDTO>(wmiprocessor);
            processor.Architecture = WMIConverter.ConvertArchitecture(wmiprocessor.Architecture);
            return processor; 
        }
        


    }
}
