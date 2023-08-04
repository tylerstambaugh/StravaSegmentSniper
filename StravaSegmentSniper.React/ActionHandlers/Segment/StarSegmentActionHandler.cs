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

        public async Task<StarSegmentModel> HandleStarSegment(StarSegmentRequest request, string userId)
        {
            var model = new StarSegmentModel(request.SegmentId, request.StarSegment, userId);

            var result = await _stravaApiSegment.StarSegment(model);

            StarSegmentModel response = new StarSegmentModel
            {
                SegmentId = result.SegmentId,
                IsStarred = result.Starred
            };

            return response;
        }
    }
}
