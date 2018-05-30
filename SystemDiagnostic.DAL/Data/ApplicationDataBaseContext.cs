using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SystemDiagnostic.Entitites;
using SystemDiagnostic.Entitites.ComputerComponents;
using SystemDiagnostic.Entitites.MonitoringInformation;
using SystemDiagnostic.Entitites.OperatingInformation;

namespace SystemDiagnostic.DAL.Data
{
    public abstract class ApplicationDataBaseContext
    {
        public DbSet<Computer> Computers { get; set; }
        public DbSet<DiskDrive> DiskDrives { get; set; }
        public DbSet<MotherBoard> MotherBoards { get; set; }
        public DbSet<PhysicalMemory> PhysicalMemories { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<VideoCard> VideoCards { get; set; }
        public DbSet<Process> Processes { get; set; }
        public DbSet<ProcessInformation> ProcessInformations { get; set; }
        public DbSet<ProcessPerfomance> ProcessPerfomances { get; set; }
        public DbSet<ComputerSystem> ComputerSystems { get; set; }
    }
}
