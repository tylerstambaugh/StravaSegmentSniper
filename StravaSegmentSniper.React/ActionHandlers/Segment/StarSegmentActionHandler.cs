using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using System.Security.Claims;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public class StarSegmentActionHandler : IStarSegmentActionHandler
    {
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStravaApiSegment _stravaApiSegment;

        public StarSegmentActionHandler(IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor, IStravaApiSegment stravaApiSegment)
        {
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
            _stravaApiSegment = stravaApiSegment;
        }

        public async Task<StarSegmentModel> HandleStarSegment(StarSegmentActionHandlerContract contract)
        {
            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var userId = user.Id;

            var model = new StarSegmentModel(contract.SegmentId, contract.StarSegment);

            var result = await _stravaApiSegment.StarSegment(userId, model);

            StarSegmentModel response = new StarSegmentModel(result.Id, result.Starred);

            return response;
        }
    }
}
