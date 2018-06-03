using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.Entitites;
using SystemDiagnostic.ViewModel;

namespace SystemDiagnostic.WebAPI.Controllers
{
    public class ComputerController : Controller
    {
        private readonly IComputerService _computerService;

        public ComputerController(IComputerService computerService)
        {
            _computerService = computerService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {

            return Ok(_computerService.GetAllComputers());
        }        
        
        [Route("api/[controller]/{id}")]
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            ComputerViewModel computer = _computerService.GetComputerById(id);
            if (computer != null)
                return Ok(computer);
            else
                return NotFound();
        }
        
        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Register([FromBody]RegisterComputerModel registerComputerModel)
        {
            if (ModelState.IsValid)
            {
                if (_computerService.CheckUniqueLogin(registerComputerModel.Login))
                {
                   ComputerViewModel computer = _computerService.RegisterNewComputer(registerComputerModel.Login
                        , registerComputerModel.Password);
                    return Ok(computer);
                }
                else
                    return BadRequest("Login already use");
            }
            else
                return BadRequest(ModelState);
        }        
        
        [Route("api/[controller]/delete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (_computerService.DeleteComputerById(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
