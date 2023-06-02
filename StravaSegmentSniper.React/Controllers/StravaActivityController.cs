using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers;
using StravaSegmentSniper.React.ActionHandlers.Contracts;
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
        public List<SummaryActivityModel> SummaryActivityForTimeRange([FromBody] DateRangeParametersContract dateRangeParameters)
        {
            int startDate = 9345693;
            int endDate = 9235479;

            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var userId = user.StravaAthleteId;


            List<SummaryActivityModel> listOfActivities = _stravaAPIActivity
                .GetSummaryActivityForTimeRange(startDate, endDate, userId).Result;

            return listOfActivities;
        }

        [HttpGet]
        [ActionName("ActivityListById")]
        public ActivityListModel DetailedActivityById([FromQuery]long activityId)
        {
           HandleGetActivityByIdContract contract = new HandleGetActivityByIdContract
            {
                   activityId = activityId
            };

            return _stravaActivityActionHandler.HandleGetActivityById(contract);
     
        }
         
    }
  
}
