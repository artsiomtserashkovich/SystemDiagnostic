using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DiskDriveController : Controller
    {
        private readonly IDiskDriveService _diskDriveService;

        public DiskDriveController(IDiskDriveService diskDriveService)
        {
            _diskDriveService = diskDriveService;
        }
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok(_diskDriveService.GetDiskDrives());
        }

        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(string id)
        {
            DiskDrive diskDrive = _diskDriveService.GetDiskDriveById(id);
            if (diskDrive != null)
                return Ok(diskDrive);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        [Route("api/[controller]/delete")]
        public IActionResult Delete(string id)
        {
            if (_diskDriveService.DeleteDiskDriveById(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
