using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using System.Security.Claims;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
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

        [HttpGet("summaryActivity/{startDate}/{endDate}")]
        public List<SummaryActivityModel> SummaryActivityForTimeRange(DateTime start, DateTime end)
        {
            int startDate = 9345693;
            int endDate = 9235479;

            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var userId = user.StravaAthleteId;


            List<SummaryActivityModel> listOfActivities = _stravaAPIActivity
                .GetSummaryActivityForTimeRange(startDate, endDate, userId).Result;

            return listOfActivities;
        }

        [HttpGet("activitylist")]
        //[Route("/activitylist/{activityId}")]
        public DetailedActivityModel DetailedActivityById([FromQuery]long activityId)
        {
            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var stravaAthleteId = user.StravaAthleteId;
            DetailedActivityModel activity = _stravaAPIActivity.GetDetailedActivityById(activityId, stravaAthleteId).Result;

            return activity;
        }

       // [HttpGet]
       // [Route("/TestGet/{test}")]
       //[ActionName("testget")]
       // public string TestGet([FromQuery] string test)
       // {
       //     return $"test string was = {test}";
       // }
    }
}
