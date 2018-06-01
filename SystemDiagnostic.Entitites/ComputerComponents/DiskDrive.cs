using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemDiagnostic.Entitites.ComputerComponents
{
    public class DiskDrive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [ForeignKey("Computer")]
        public string ComputerId { get; set; }
        public Computer Computer { get; set; }

        public string ComputerDiskDriveId { get; set; }
        public string Model { get; set; }
        public double SizeGB { get; set; }
        public string MediaType { get; set; }
    }
}
