using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Activity;
using StravaSegmentSniper.React.ActionHandlers.Activity.Contracts;
using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using System.Security.Claims;
using static StravaSegmentSniper.Services.Enums.ActivityTypeEnum;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StravaActivityController : ControllerBase
    {
        private readonly IStravaActivityActionHandler _stravaActivityActionHandler;

        public StravaActivityController(IStravaActivityActionHandler stravaActivityActionHandler)
        {
            _stravaActivityActionHandler = stravaActivityActionHandler;
        }

        [HttpPost]
        [ActionName("ActivityListByDates")]
        [Consumes("application/json")]
        public List<ActivityListModel> SummaryActivityForTimeRange([FromBody] DateRangeParametersContract dateRangeParameters)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            ActivityType parsedActivity;
            if (Enum.TryParse<ActivityType>(dateRangeParameters.ActivityType, true, out parsedActivity));
            
            if(parsedActivity != null)
            {
            HandleGetSummaryActivitiesForDateRangeContract contract = new HandleGetSummaryActivitiesForDateRangeContract(
                 (DateTime)dateRangeParameters.StartDate,
                (DateTime)dateRangeParameters.EndDate,
                parsedActivity
            );

                var returnList = _stravaActivityActionHandler.HandleGetActivitListForDateRange(contract, userId);

                return returnList;
            }
            else
            {
                throw new ArgumentException("Invalid Activity Search Parameters");
            }            
        }

        [HttpGet]
        [ActionName("ActivityListById")]
        public IActionResult StravaActivityListById([FromQuery]string activityId)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            HandleGetActivityByIdContract contract = new HandleGetActivityByIdContract
            {
                   activityId = activityId
            };
            var returnList = _stravaActivityActionHandler.HandleGetActivityListById(contract, userId);
            if (returnList != null)
                return Ok(returnList);
            else
                return BadRequest("No activity found with that Id");
        }

        [HttpGet]
        [ActionName("ActivityDetailtById")]
        public IActionResult StravaActivityDetailById([FromQuery] string activityId)
        {
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            HandleGetActivityByIdContract contract = new HandleGetActivityByIdContract
            {
                activityId = activityId
            };

            return Ok(_stravaActivityActionHandler.HandleGetActivityDetailById(contract));
        }

    }
  
}
