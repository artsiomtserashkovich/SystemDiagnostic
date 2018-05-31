using System;
using System.Collections.Generic;
using System.Text;
using SystemDiagnostic.DAL.Data;
using SystemDiagnostic.DAL.Interfaces;
using SystemDiagnostic.DAL.Repositories;

namespace SystemDiagnostic.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDataBaseContext _applicationDataBaseContext;

        public UnitOfWork(ApplicationDataBaseContext applicationDataBaseContext)
        {
            _applicationDataBaseContext = applicationDataBaseContext;
            Computers = new ComputerRepository(_applicationDataBaseContext);
            ComputerSystems = new ComputerSystemRepository(_applicationDataBaseContext);
            Processors = new ProcessorRepository(_applicationDataBaseContext);
            PhysicalMemories = new PhysicalMemoryRepository(_applicationDataBaseContext);
            DiskDrives = new DiskDriveRepository(_applicationDataBaseContext);
            MotherBoards = new MotherBoardRepository(_applicationDataBaseContext);
            VideoCards = new VideoCardRepository(_applicationDataBaseContext);
            Processes = new ProcessRepository(_applicationDataBaseContext);
            ProcessesInformation = new ProcessInformationRepository(_applicationDataBaseContext);
            ProcessesPerfomance= new ProcessPerfomanceRepository(_applicationDataBaseContext);
        }

        public IComputerRepository Computers { get; private set; }

        public IComputerSystemRepository ComputerSystems { get; private set; }

        public IProcessorRepository Processors { get; private set; }

        public IPhysicalMemoryRepository PhysicalMemories { get; private set; }

        public IDiskDriveRepository DiskDrives { get; private set; }

        public IMotherBoardRepository MotherBoards { get; private set; }

        public IVideoCardRepository VideoCards { get; private set; }

        public IProcessRepository Processes { get; private set; }

        public IProcessInformationRepository ProcessesInformation { get; private set; }

        public IProcessPerfomanceRepository ProcessesPerfomance { get; private set; }

        public void Dispose()
        {
            _applicationDataBaseContext.Dispose();
        }

        public void SaveChanges()
        {
            _applicationDataBaseContext.SaveChanges();
            GC.SuppressFinalize(this);
        }
    }
}
