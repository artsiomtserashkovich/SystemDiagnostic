using System;
using System.Collections.Generic;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class VideoCardService
    {
        private readonly IMapper _mapper;
        private readonly IWMIManagers _wmimanagers;

        public VideoCardService(IMapper mapper,IWMIManagers wmiManagers){
            _wmimanagers = wmiManagers;
            _mapper = mapper;
        }

        public IEnumerable<VideoCardDTO> GetVideoCards(){
            IEnumerable<WMIVideoController> wmiVideoControllers = _wmimanagers.WMIVideoController.GetWMIVideoControllers();
            return _mapper.Map<IEnumerable<WMIVideoController>,IEnumerable<VideoCardDTO>>(wmiVideoControllers);        
        }
    }
}
