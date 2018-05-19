using System;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class MotherBoardService
    {
        private readonly IWMIManagers _wmimanagers;
        private readonly IMapper _mapper;
        public MotherBoardService(IMapper mapper,IWMIManagers wmimanagers){
            _wmimanagers = wmimanagers;
            _mapper = mapper;
        }

        public MotherBoardDTO GetMotherBoard(){
            WMIBaseBoard wmiBaseBoard = _wmimanagers.WMIBaseBoardManager.GetWMIBaseBoard();
            return _mapper.Map<WMIBaseBoard,MotherBoardDTO>(wmiBaseBoard);
        }
    }
}
