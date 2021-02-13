using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tagger.Business;
using tagger.Models;

namespace tagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TagController : ControllerBase
    {
        private readonly IVideoBusiness _business;

        public TagController(IVideoBusiness business)
        {
            _business = business;
        }

        /// <summary>
        /// It lists all tagged videos.
        /// </summary>
        /// <returns>List all tagged videos.</returns>
        /// <response code="200"> When tagged videos are listed. </response>
        /// <response code="500"> When there is an error when listing tagged videos. </response>
        [HttpGet]
        [ProducesResponseType(typeof(Video), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public ActionResult<List<Video>> Get()
        {
            return _business.GetVideo();
        }

        /// <summary>
        /// It tags a video.
        /// </summary>
        /// <param name="video">Video to be tagged.</param>
        /// <returns>Tagged video.</returns>
        /// <response code="201"> When video are tagged. </response>
        /// <response code="400"> When a required field was not informed or entered incorrectly.</response>
        /// <response code="500"> When there is an error when tagging a video. </response>
        [HttpPost]
        [ProducesResponseType(typeof(Video), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public ActionResult Create([FromBody] Video video)
        {
            _business.TagVideo(video);
            return Ok(video);
        }
    }
}