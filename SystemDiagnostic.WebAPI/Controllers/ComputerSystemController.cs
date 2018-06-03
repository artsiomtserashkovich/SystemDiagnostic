using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.ViewModel;

namespace SystemDiagnostic.WebAPI.Controllers
{
    
    public class ComputerSystemController : Controller
    {

        private readonly IComputerSystemService _computerSystemService;

        public ComputerSystemController(IComputerSystemService computerSystemService)
        {
            _computerSystemService = computerSystemService;
        }
        
        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_computerSystemService.GetComputerSystems());
        }
        
        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(string id)
        {
            ComputerSystemViewModel computerSystem = _computerSystemService
                .GetComputerSystemByComputerId(id);
            if (computerSystem != null)
                return Ok(computerSystem);
            else
                return NotFound();
        }                
        
        [HttpDelete("{id}")]
        [Route("api/[controller]/delete")]
        public IActionResult Delete(string id)
        {
            if (_computerSystemService.DeleteComputerSystemById(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
