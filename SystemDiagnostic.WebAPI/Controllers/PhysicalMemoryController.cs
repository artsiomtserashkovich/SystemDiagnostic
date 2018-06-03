using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.WebAPI.Controllers
{    
    public class PhysicalMemoryController : Controller
    {
        private readonly IPhysicalMemoryService _physicalMemoryService;

        public PhysicalMemoryController(IPhysicalMemoryService physicalMemoryService)
        {
            _physicalMemoryService = physicalMemoryService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_physicalMemoryService.GetPhysicalMemories());
        }

        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(string id)
        {
            PhysicalMemory physicalMemory = _physicalMemoryService.GetPhysicalMemoryById(id);
            if (physicalMemory != null)
                return Ok(physicalMemory);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        [Route("api/[controller]/delete")]
        public IActionResult Delete(string id)
        {
            if (_physicalMemoryService.DeletePhysicalMemoryById(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
