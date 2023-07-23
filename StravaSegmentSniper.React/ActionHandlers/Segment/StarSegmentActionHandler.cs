using StravaSegmentSniper.Services.Internal.Services;
using System.Security.Claims;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public class StarSegmentActionHandler : IStarSegmentActionHandler
    {
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StarSegmentActionHandler(IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor)
        {
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task HandleStarSegment(StarSegmentActionHandlerContract contract)
        {
            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var userId = user.Id;
        }
    }
}
