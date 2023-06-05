using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Activity;
using StravaSegmentSniper.React.ActionHandlers.Activity.Contracts;
using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using System.Security.Claims;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StravaActivityController : ControllerBase
    {
        private readonly IStravaAPIActivity _stravaAPIActivity;
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStravaActivityActionHandler _stravaActivityActionHandler;

        public StravaActivityController(IStravaAPIActivity stravaAPIActivity, IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor, IStravaActivityActionHandler stravaActivityActionHandler)
        {
            _stravaAPIActivity = stravaAPIActivity;
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
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
        public List<ActivityListModel> DetailedActivityById([FromQuery]long activityId)
        {
           HandleGetActivityByIdContract contract = new HandleGetActivityByIdContract
            {
                   activityId = activityId
            };

            return _stravaActivityActionHandler.HandleGetActivityById(contract);
     
        }
         
    }
  
}
