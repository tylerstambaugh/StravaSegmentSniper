using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using StravaSegmentSniper.Services.UIModels.Segment;
using System.Security.Claims;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public class StravaSegmentActionHandler : IStravaSegmentActionHandler
    {
        private readonly IStravaAPIActivity _stravaAPIActivity;
        private readonly IStravaAPISegment _stravaSegment;
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StravaSegmentActionHandler(IStravaAPIActivity stravaAPIActivity, IStravaAPISegment stravaSegment, IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor) {
            _stravaAPIActivity = stravaAPIActivity;
            _stravaSegment = stravaSegment;
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<SnipedSegmentUIModel> HandleSnipingSegments(SegmentSniperContract contract)
        {
            //get detailed activity by Id
            //get detailed segments for each segment Id
            //do sniping on list of segments

            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var stravaAthleteId = user.StravaAthleteId;
            DetailedActivityModel detailedActivityModel = _stravaAPIActivity.GetDetailedActivityById(contract.ActivityId, stravaAthleteId).Result;



            throw new NotImplementedException();

        }
    }
}
