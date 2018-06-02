using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemDiagnostic.Entitites.OperatingInformation
{
    public class ComputerSystem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        [ForeignKey("Computer")]
        public string ComputerId { get; set; }
        public Computer Computer { get; set; }
        
        public string ComputerName { get; set; }
        public string DNSHostName { get; set; }
        public string CurrentUsername { get; set; }
    }
}
