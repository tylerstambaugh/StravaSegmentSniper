using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using System.Security.Claims;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class StravaActivityController : ControllerBase
    {
        private readonly IAthleteActivityService _athleteActivityService;
        private readonly IStravaAPIActivity _stravaAPIActivity;
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StravaActivityController(IAthleteActivityService athleteActivityService, IStravaAPIActivity stravaAPIActivity, IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor)
        {
            _athleteActivityService = athleteActivityService;
            _stravaAPIActivity = stravaAPIActivity;
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
        }

        // GET api/<ActivityController>
        [HttpGet]
        public List<SummaryActivityModel> GetStravaSummaryActivityForTimeRange()
        {
            int startDate = 9345693;
            int endDate = 9235479;

            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var userId = user.StravaAthleteId;


            List<SummaryActivityModel> listOfActivities = _stravaAPIActivity
                .GetSummaryActivityForTimeRange(startDate, endDate, userId).Result;

            return listOfActivities;
        }

        [HttpGet("{activityId}")]
        [ActionName("ActivityList")]
        public DetailedActivityModel GetStravaDetailedActivityById(int activityId)
        {
            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var stravaAthleteId = user.StravaAthleteId;
            DetailedActivityModel activity = _stravaAPIActivity.GetDetailedActivityById(activityId, stravaAthleteId).Result;

            return activity;
        }


    }
}
