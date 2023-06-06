using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Activity;
using StravaSegmentSniper.React.ActionHandlers.Activity.Contracts;
using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.UIModels.Activity;

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
        public List<ActivityListModel> SummaryActivityForTimeRange([FromBody] DateRangeParametersContract dateRangeParameters)
        {
            HandleGetSummaryActivitiesForDateRangeContract contract = new HandleGetSummaryActivitiesForDateRangeContract
            {
                StartDate = (DateTime)dateRangeParameters.StartDate,
                EndDate = (DateTime)dateRangeParameters.EndDate
            };

            var returnList = _stravaActivityActionHandler.HandleGetSummaryActivitiesForDateRange(contract);

            return returnList;

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
