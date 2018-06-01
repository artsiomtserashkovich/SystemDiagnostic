using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemDiagnostic.Entitites.ComputerComponents
{
    public class Processor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [ForeignKey("Computer")]
        public string ComputerId { get; set; }
        public Computer Computer { get; set; }

        public string ComputerProcessorId { get; set; }
        [Required]
        public string  Name { get; set; }
        public string Description { get; set; }
        public int NumberOfCores { get; set; }
        public int ClockFrequency { get; set; }
        public string Architecture { get; set; }
        public int L2CacheSize { get; set; }
        public int L3CacheSize { get; set; }
    }
}
