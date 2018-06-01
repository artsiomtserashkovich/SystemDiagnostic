using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;

namespace SystemDiagnostic.Diagnostic.Server.Services
{
    class ComputerComponentService : IComputerComponentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ComputerComponentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public void UpdateDiskDrives(string computerLogin, IEnumerable<DiskDriveDTO> diskDrives)
        {
            throw new NotImplementedException();
        }

        public void UpdateMotherBoard(string computerLogin, MotherBoardDTO motherBoard)
        {
            throw new NotImplementedException();
        }

        public void UpdatePhysicalMemories(string computerLogin, IEnumerable<PhysicalMemoryDTO> physicalMemories)
        {
            throw new NotImplementedException();
        }

        public void UpdateProcessor(string computerLogin, ProcessorDTO processor)
        {
            throw new NotImplementedException();
        }

        public void UpdateVideoCards(string computerLogin, IEnumerable<VideoCardDTO> videoCards)
        {
            throw new NotImplementedException();
        }
    }
}
