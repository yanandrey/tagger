using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using tagger.Models;
using tagger.Service;

namespace tagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VideoController : ControllerBase
    {
        private readonly TaggerService _service;

        public VideoController(TaggerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<Video>> Get()
        {
            return _service.Get();
        }

        [HttpPost]
        public ActionResult Create([FromBody] Video video)
        {
            _service.Create(video);
            return Ok(video);
        }
    }
}