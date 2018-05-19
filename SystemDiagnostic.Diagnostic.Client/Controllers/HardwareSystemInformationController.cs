using System;
using System.Collections.Generic;
using SystemDiagnostic.Diagnostic.Client.Services;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Client.Controllers
{
    public class HardwareSystemInformationController
    {
        private MotherBoardService _motherBoardService;
        private DiskDriveService _diskDriveService;
        private PhysicalMemoryService _physicalMemoryService;
        private ProcessorService _processorService;
        private VideoCardService _videoCardService;

        public HardwareSystemInformationController(
            MotherBoardService motherBoardService,
            DiskDriveService diskDriveService,
            PhysicalMemoryService physicalMemoryService,
            ProcessorService processorService,
            VideoCardService videoCardService
        )
        {
            _motherBoardService = motherBoardService;
            _diskDriveService = diskDriveService;
            _physicalMemoryService = physicalMemoryService;
            _processorService = processorService;
            _videoCardService = videoCardService;
        }

        public ComputerHardwareInformationDTO GetComputerHardwareInformation(){
            return new ComputerHardwareInformationDTO{
                Processor = _processorService.GetProcessor(),
                MotherBoard = _motherBoardService.GetMotherBoard(),
                VideoCards = _videoCardService.GetVideoCards(),
                PhysicalMemories = _physicalMemoryService.GetPhysicalMemories(),
                DiskDrives = _diskDriveService.GetDiskDrives()
            };
        }

        public IEnumerable<PhysicalMemoryDTO> GetPhysicalMemories(){
            return _physicalMemoryService.GetPhysicalMemories();
        }

        public IEnumerable<DiskDriveDTO> GetDiskDrives(){
            return _diskDriveService.GetDiskDrives();
        }

        public IEnumerable<VideoCardDTO> GetVideoCards(){
            return _videoCardService.GetVideoCards();
        }

        public MotherBoardDTO GetMotherBoard(){
            return _motherBoardService.GetMotherBoard();
        }

        public ProcessorDTO GetProcessor(){
            return _processorService.GetProcessor();
        }
    }
}
