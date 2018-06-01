using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemDiagnostic.Entitites.ComputerComponents
{
    public class VideoCard
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [ForeignKey("Computer")]
        public string ComputerId { get; set; }
        public Computer Computer { get; set; }

        [Required]
        public string Name { get; set; }
        public string VideoProcessor { get; set; }
        public double AdapterRAMGB { get; set; }
        public string AdapterCompatibility { get; set; }
        public int MaxRefreshRate { get; set; }
    }
}
