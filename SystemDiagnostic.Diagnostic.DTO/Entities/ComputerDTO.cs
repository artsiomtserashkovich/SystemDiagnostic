using System;
using System.Collections.Generic;

namespace SystemDiagnostic.Diagnostic.DTO.Entities
{
    public class ComputerDTO
    {
        
        public string Name {get;set;}
        public ProcessorDTO Processor {get;set;}
        public MotherBoardDTO MotherBoard {get;set;}
        public IEnumerable<VideoCardDTO> VideoCards {get;set;}
        public IEnumerable<PhysicalMemoryDTO> PhysicalMemories {get;set;}
        public IEnumerable<DiskDriveDTO> DiskDrives {get;set;}
    }
}
