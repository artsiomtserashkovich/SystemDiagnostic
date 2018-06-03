using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SystemDiagnostic.ViewModel
{
    public class ComputerViewModel
    {
        public string Id { get; set; }       
        public string Login { get; set; }
        public ComputerSystemViewModel ComputerSystem { get; set; }
        public string ProcessorId { get; set; }
        public string MotherBoardId { get; set; }
        public IEnumerable<string> DiskDrivesId { get; set; }
        public IEnumerable<string> PhysicalMemoriesId { get; set; }
        public IEnumerable<string> VideoCardsId { get; set; }
        public IEnumerable<string> ProcessesId { get; set; }
        public bool IsConnected { get; set; }
    }
}
