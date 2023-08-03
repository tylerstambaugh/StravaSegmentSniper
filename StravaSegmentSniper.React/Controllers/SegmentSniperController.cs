using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Segment;
using StravaSegmentSniper.React.Controllers.Contracts;
using System.Security.Claims;

namespace StravaSegmentSniper.React.Controllers
{

    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SegmentSniperController : ControllerBase
    {
        private readonly ISnipeSegmentActionHandler _stravaSegmentActionHandler;

        public SegmentSniperController(ISnipeSegmentActionHandler stravaSegmentActionHandler)
        {
            _stravaSegmentActionHandler = stravaSegmentActionHandler;
        }

        [HttpPost]
        [ActionName("SnipeSegments")]
        public IActionResult SnipeSegments(SegmentSniperContract contract)
        {
            //need to check API usage
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var returnList = _stravaSegmentActionHandler.HandleSnipingSegments(contract, userId);
            if (returnList != null)
                return Ok(returnList);
            else
                return BadRequest("Unable to snipe segments with info provided."); ;
        }
    }

}
