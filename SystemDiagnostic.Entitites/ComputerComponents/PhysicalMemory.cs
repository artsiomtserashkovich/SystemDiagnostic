using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemDiagnostic.Entitites.ComputerComponents
{
    public class PhysicalMemory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [ForeignKey("Computer")]
        public string ComputerId { get; set; }
        public Computer Computer { get; set; }

        [Required]
        public string ComputerPhysicalMemoryId { get; set; }
        public double CapacityGB { get; set; }
        public string FormFactor { get; set; }
        public string Manufacturer { get; set; }
        public int Speed { get; set; }
    }
}
