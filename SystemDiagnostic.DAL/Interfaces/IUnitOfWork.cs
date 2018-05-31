using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDiagnostic.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IComputerRepository Computers { get; }
        IComputerSystemRepository ComputerSystems { get; }
        IProcessorRepository Processors { get; }
        IPhysicalMemoryRepository PhysicalMemories { get; }
        IDiskDriveRepository DiskDrives { get; }
        IMotherBoardRepository MotherBoards { get; }
        IVideoCardRepository VideoCards { get; }
        IProcessRepository Processes { get; }
        IProcessInformationRepository ProcessesInformation { get; }
        IProcessPerfomanceRepository ProcessesPerfomance { get; }

        void SaveChanges();
    }
}
