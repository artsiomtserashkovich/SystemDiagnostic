using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemDiagnostic.Entitites.MonitoringInformation
{
    public class ProcessInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity]
        public string Id { get; set; }
        [Required]
        [ForeignKey("Process")]
        public string ProcessId { get; set; }
        public Process Process { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public string CommandLine { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DataType(DataType.DateTime)]
        public DateTime UpdateTime { get; set; }
    }
}
