using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SystemDiagnostic.Entitites.ComputerComponents;
using SystemDiagnostic.Entitites.MonitoringInformation;
using SystemDiagnostic.Entitites.OperatingInformation;

namespace SystemDiagnostic.Entitites
{
    public class Computer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public Processor Processor { get; set; }
        public MotherBoard MotherBoard { get; set; }
        public ICollection<DiskDrive> DiskDrives { get; set; }
        public ICollection<PhysicalMemory> PhysicalMemories { get; set; }
        public ICollection<VideoCard> VideoCards { get; set; }
        public ComputerSystem ComputerSystem { get; set; }
        public ICollection<Process> Processes { get; set; }
        public bool IsConnected { get; set; }
    }
}
