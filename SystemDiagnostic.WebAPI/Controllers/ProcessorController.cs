using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.WebAPI.Controllers
{
    
    public class ProcessorController : Controller
    {
        private readonly IProcessorService _processorService;

        public ProcessorController(IProcessorService processorService)
        {
            _processorService = processorService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_processorService.GetProcessors());
        }
               
        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(string id)
        {
            Processor processor = _processorService.GetProcessorById(id);
            if (processor != null)
                return Ok(processor);
            else
                return NotFound();
        }
        
        [HttpDelete("{id}")]
        [Route("api/[controller]/delete")]
        public IActionResult Delete(string id)
        {
            if (_processorService.DeleteProcessorById(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
