using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Segment;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using System.Security.Claims;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StravaSegmentController : ControllerBase
    {
        private readonly IStarSegmentActionHandler _starSegmentActionHandler;


        public StravaSegmentController(IStarSegmentActionHandler starSegmentActionHandler)
        {
            _starSegmentActionHandler = starSegmentActionHandler;
        }

        // GET api/<Segment>/5
        [HttpGet("{id}")]
        public DetailedSegmentModel Get(int id)
        {
            return new DetailedSegmentModel();
        }

        [HttpPost]
        [ActionName("StarSegment")]
        public IActionResult StarSegment([FromBody] StarSegmentRequest request)
        {
            request.UserId= HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            
            var response = _starSegmentActionHandler.HandleStarSegment(request).Result;
            if (response == null)
            {
                return BadRequest("null object response from handler");
            }
            else if (response.IsStarred == request.StarSegment)
            {
                return BadRequest("failed to change state of star on segment");
            }
            else
            {
                return Ok(response);
            }
        }
    }
}
