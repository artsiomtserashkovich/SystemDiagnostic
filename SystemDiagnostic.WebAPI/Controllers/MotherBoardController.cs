using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.WebAPI.Controllers
{
    
    public class MotherBoardController : Controller
    {
        private readonly IMotherBoardService _motherBoardService;

        public MotherBoardController(IMotherBoardService motherBoardService)
        {
            _motherBoardService = motherBoardService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            return Ok(_motherBoardService.GetMotherBoards());
        }
        
        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(string id)
        {
            MotherBoard motherBoard = _motherBoardService.GetMotherBoardById(id);
            if (motherBoard != null)
                return Ok(motherBoard);
            else
                return NotFound();
        }
       
        [HttpDelete("{id}")]
        [Route("api/[controller]/delete")]
        public IActionResult Delete(string id)
        {
            if (_motherBoardService.DeleteMotherBoardById(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
