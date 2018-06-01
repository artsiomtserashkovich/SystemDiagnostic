using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.Diagnostic.DTO.Entities;

namespace SystemDiagnostic.Diagnostic.Server.Services.Interfaces
{
    interface IComputerComponentService
    {
        void UpdateDiskDrives(string computerLogin, IEnumerable<DiskDriveDTO> diskDrives);
        void UpdateProcessor(string computerLogin, ProcessorDTO processor);
        void UpdateVideoCards(string computerLogin, IEnumerable<VideoCardDTO> videoCards);
        void UpdateMotherBoard(string computerLogin, MotherBoardDTO motherBoard);
        void UpdatePhysicalMemories(string computerLogin, IEnumerable<PhysicalMemoryDTO> physicalMemories);        
    }
}