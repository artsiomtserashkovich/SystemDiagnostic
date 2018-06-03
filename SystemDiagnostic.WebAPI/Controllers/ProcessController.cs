using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.Entitites.MonitoringInformation;
using SystemDiagnostic.ViewModel.ViewModel;

namespace SystemDiagnostic.WebAPI.Controllers
{    
    public class ProcessController : Controller
    {
        private IProcessService _processService;
        public ProcessController(IProcessService processSerivce)
        {
            _processService = processSerivce;
        }
        
        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(string id)
        {
            Process process = _processService.GetProcessById(id);
            if (process != null)
                return Ok(process);
            else
                return NotFound();
        }  
        
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get([FromBody] GetProcessRequest request)
        {
            Process process = _processService
                .GetProcessByNameAndComputerId(request.Name, request.ComputerId);
            if (process != null)
                return Ok(process);
            else
                return NotFound();       
        }

        [HttpDelete("{id}")]
        [Route("api/[controller]/delete")]
        public IActionResult Delete(string id)
        {
            if (_processService.DeleteProcessById(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
