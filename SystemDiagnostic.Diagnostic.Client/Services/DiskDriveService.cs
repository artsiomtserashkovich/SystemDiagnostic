using System;
using System.Collections.Generic;
using AutoMapper;
using SystemDiagnostic.Diagnostic.Client.WMI.Entities;
using SystemDiagnostic.Diagnostic.Client.WMI.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Services
{
    public class DiskDriveService
    {
        private readonly IMapper _mapper;
        private readonly IWMIManagers _wmimanagers;

        public DiskDriveService(IMapper mapper,IWMIManagers wmimanagers){
            _mapper = mapper;
            _wmimanagers = wmimanagers;
        }
        public IEnumerable<DiskDriveDTO> GetDiskDrives(){
            IEnumerable<WMIDiskDrive> wmidiskdrives = _wmimanagers.WMIDiskDriveManager.GetWMIDiskDrives();
            return _mapper.Map<IEnumerable<WMIDiskDrive>,IEnumerable<DiskDriveDTO>>(wmidiskdrives);
        }
    }
}
