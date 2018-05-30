using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SystemDiagnostic.Entitites.MonitoringInformation
{
    public class ProcessPerfomance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public int ComputerProcessId { get; set; }
        [Required]
        [ForeignKey("Process")]
        public string ProcessId { get; set; }
        public Process Process { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DataType(DataType.DateTime)]
        public DateTime RecordDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }
        [Required]
        public int PercentCPUUsage { get; set; }
        [Required]
        public int RamMemoryUsageMB { get; set; }
    }
}
