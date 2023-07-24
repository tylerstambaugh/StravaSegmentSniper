using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Segment;
using StravaSegmentSniper.Services.Internal.Models.Segment;

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
        public IActionResult StarSegment([FromBody] StarSegmentActionHandlerContract contract)
        {
            var response = _starSegmentActionHandler.HandleStarSegment(contract).Result;
            if (response == null)
            {
                return BadRequest("null object response from handler");
            }
            else if (response.IsStarred == contract.StarSegment)
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
