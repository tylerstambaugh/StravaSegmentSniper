using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Activity;
using StravaSegmentSniper.React.ActionHandlers.Activity.Contracts;
using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Enums;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.UIModels.Activity;
using System.Net;
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

            ActivityType parsedActivity;
            if (Enum.TryParse<ActivityType>(dateRangeParameters.ActivityType, true, out parsedActivity));
            
            if(parsedActivity != null)
            {
            HandleGetSummaryActivitiesForDateRangeContract contract = new HandleGetSummaryActivitiesForDateRangeContract(
                 (DateTime)dateRangeParameters.StartDate,
                (DateTime)dateRangeParameters.EndDate,
                parsedActivity
            );

                var returnList = _stravaActivityActionHandler.HandleGetActivitListForDateRange(contract);

                return returnList;
            }
            else
            {
                throw new ArgumentException("Invalid Activity Search Parameters");
            }

            
        }

        [HttpGet]
        [ActionName("ActivityListById")]
        public List<ActivityListModel> StravaActivityListById([FromQuery]long activityId)
        {
           HandleGetActivityByIdContract contract = new HandleGetActivityByIdContract
            {
                   activityId = activityId
            };

            return _stravaActivityActionHandler.HandleGetActivityListById(contract);     
        }

        [HttpGet]
        [ActionName("ActivityDetailtById")]
        public DetailedActivityUIModel StravaActivityDetailById([FromQuery] long activityId)
        {
            HandleGetActivityByIdContract contract = new HandleGetActivityByIdContract
            {
                activityId = activityId
            };

            return _stravaActivityActionHandler.HandleGetActivityDetailById(contract);
        }

    }
  
}
