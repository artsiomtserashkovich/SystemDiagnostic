using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.Diagnostic.DTO.Entities;
using SystemDiagnostic.Diagnostic.Server.Services.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

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
            IEnumerable<DiskDrive> diskDrivesEntity = _unitOfWork.DiskDrives.GetDiskDrivesByComputerLogin(computerLogin);
            if (diskDrivesEntity != null)
                foreach (DiskDrive diskDrive in diskDrivesEntity)
                    _unitOfWork.DiskDrives.Remove(diskDrive);
            string computerId = _unitOfWork.Computers.GetIdByLogin(computerLogin);
            foreach(DiskDriveDTO diskDrive in diskDrives)
            {
                DiskDrive diskDriveEntity = _mapper.Map<DiskDriveDTO, DiskDrive>(diskDrive);
                diskDriveEntity.ComputerId = computerId;
                _unitOfWork.DiskDrives.Add(diskDriveEntity);                
            }
            _unitOfWork.SaveChanges();
        }

        public void UpdateMotherBoard(string computerLogin, MotherBoardDTO motherBoard)
        {
            MotherBoard _motherBoard = _unitOfWork.MotherBoards
                .GetMotherBoardByComputerLogin(computerLogin);
            if(_motherBoard != null)
            {
                _unitOfWork.MotherBoards.Remove(_motherBoard);
                _motherBoard = _mapper.Map<MotherBoardDTO, MotherBoard>(motherBoard, _motherBoard);
            }
            else
            {
                _motherBoard = _mapper.Map<MotherBoardDTO, MotherBoard>(motherBoard);
                _motherBoard.ComputerId = _unitOfWork.Computers.GetIdByLogin(computerLogin);
            }
            _unitOfWork.MotherBoards.Add(_motherBoard);
            _unitOfWork.SaveChanges();
        }

        public void UpdatePhysicalMemories(string computerLogin, IEnumerable<PhysicalMemoryDTO> physicalMemories)
        {
            IEnumerable<PhysicalMemory> physicalMemoriesEntity = _unitOfWork.PhysicalMemories
                .GetPhysicalMemoriesByComputerLogin(computerLogin);
            if (physicalMemoriesEntity != null)
                foreach (PhysicalMemory physicalMemory in physicalMemoriesEntity)
                    _unitOfWork.PhysicalMemories.Remove(physicalMemory);
            string computerId = _unitOfWork.Computers.GetIdByLogin(computerLogin);
            foreach(PhysicalMemoryDTO physicalMemory in physicalMemories)
            {
                PhysicalMemory physicalMemoryEntity = _mapper.Map<PhysicalMemoryDTO, PhysicalMemory>(physicalMemory);
                physicalMemoryEntity.ComputerId = computerId;
                _unitOfWork.PhysicalMemories.Add(physicalMemoryEntity);
            }
            _unitOfWork.SaveChanges();
        }

        public void UpdateProcessor(string computerLogin, ProcessorDTO processor)
        {
            Processor _processor = _unitOfWork.Processors.GetProcessorByComputerLogin(computerLogin);
            if(_processor != null)
            {
                _unitOfWork.Processors.Remove(_processor);
                _processor = _mapper.Map<ProcessorDTO, Processor>(processor, _processor);
            }
            else
            {
                _processor = _mapper.Map<ProcessorDTO, Processor>(processor);
                _processor.ComputerId = _unitOfWork.Computers.GetIdByLogin(computerLogin);
            }
            _unitOfWork.Processors.Add(_processor);
            _unitOfWork.SaveChanges();
        }

        public void UpdateVideoCards(string computerLogin, IEnumerable<VideoCardDTO> videoCards)
        {
            IEnumerable<VideoCard> _videoCards = _unitOfWork.VideoCards.GetVideoCardsByComputerLogin(computerLogin);
            if(_videoCards != null)            
                foreach(VideoCard videocard in _videoCards)                
                    _unitOfWork.VideoCards.Remove(videocard);
            string computerId = _unitOfWork.Computers.GetIdByLogin(computerLogin);
            foreach(VideoCardDTO videoCard in videoCards)
            {
                VideoCard videoCardEntity = _mapper.Map<VideoCardDTO, VideoCard>(videoCard);
                videoCardEntity.ComputerId = computerId;
                _unitOfWork.VideoCards.Add(videoCardEntity);
            }
            _unitOfWork.SaveChanges();
        }
    }
}
