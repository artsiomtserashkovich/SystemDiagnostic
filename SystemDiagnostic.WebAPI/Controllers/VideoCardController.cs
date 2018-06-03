using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SystemDiagnostic.BLL.Interfaces;
using SystemDiagnostic.Entitites.ComputerComponents;

namespace SystemDiagnostic.WebAPI.Controllers
{
    public class VideoCardController : Controller
    {
        private readonly IVideoCardService _videoCardService;

        public VideoCardController(IVideoCardService videoCardService)
        {
            _videoCardService = videoCardService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetAll()
        {
            return Ok(_videoCardService.GetVideoCards());
        }

        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public IActionResult Get(string id)
        {
            VideoCard videoCard = _videoCardService.GetVideoCardById(id);
            if (videoCard != null)
                return Ok(videoCard);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        [Route("api/[controller]/delete")]
        public IActionResult Delete(string id)
        {
            if (_videoCardService.DeleteVideoCardById(id))
                return NoContent();
            else
                return NotFound();
        }
    }
}
