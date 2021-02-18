using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<List<Video>> GetVideo()
        {
            return await _business.GetVideoAsync();
        }

        /// <summary>
        /// It lists all videos with a specific tag.
        /// </summary>
        /// <param name="tag">Video tag to fetch.</param>
        /// <returns>List all videos with a specific tag.</returns>
        /// <response code="200"> When videos with specific tag are listed. </response>
        /// <response code="500"> When there is an error when listing videos with specific tag. </response>
        [HttpGet("findByTag")]
        [ProducesResponseType(typeof(Video), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public ActionResult<List<Video>> GetByTag([FromQuery] string tag)
        {
            return _business.GetVideoByTag(tag);
        }

        /// <summary>
        /// It tags a video.
        /// </summary>
        /// <param name="video">Video to be tagged.</param>
        /// <returns>Tagged video.</returns>
        /// <response code="201"> When video is tagged. </response>
        /// <response code="400"> When a required field was not informed or entered incorrectly.</response>
        /// <response code="500"> When there is an error when tagging a video. </response>
        [HttpPost]
        [ProducesResponseType(typeof(Video), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Create([FromBody] Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _business.TagVideoAsync(video);
            return Ok(video);
        }

        /// <summary>
        /// It updates a tagged video.
        /// </summary>
        /// <param name="video">Tagged video to be updated.</param>
        /// <returns>Updated tagged video.</returns>
        /// <response code="200"> When a video tagged is updated. </response>
        /// <response code="400"> When a required field was not informed or entered incorrectly.</response>
        /// <response code="500"> When there is an error when updating a tagged video. </response>
        [HttpPut]
        [ProducesResponseType(typeof(Video), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Update([FromBody] Video video)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _business.UpdateVideoAsync(video);
            return Ok(video);
        }

        /// <summary>
        /// It deletes a tagged video.
        /// </summary>
        /// <param name="video">Tagged video to be deleted.</param>
        /// <returns>Deleted tagged video.</returns>
        /// <response code="204"> When a video tagged is deleted. </response>
        /// <response code="400"> When a required field was not informed or entered incorrectly.</response>
        /// <response code="500"> When there is an error when deleting a tagged video. </response>
        [HttpDelete]
        [ProducesResponseType(typeof(Video), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        [Produces("application/json")]
        public async Task<ActionResult> Delete(Video video)
        {
            await _business.DeleteVideoAsync(video);
            return NoContent();
        }
    }
}