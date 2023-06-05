using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Token;
using StravaSegmentSniper.Services.Internal.Services;
using System.Security.Claims;

namespace StravaSegmentSniper.React.ActionHandlers.StravaApiToken
{
    public class StravaApiTokenActionHandler : IStravaApiTokenActionHandler
    {
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStravaTokenService _stravaTokenService;

        public StravaApiTokenActionHandler(IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor, IStravaTokenService stravaTokenService)
        {
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
            _stravaTokenService = stravaTokenService;
        }


        public StravaApiTokenModel GetCurrentStravaApiToken()
        {
            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());

            return _stravaTokenService.GetCurrentStravaApiToken(user.Id);
        }
        public RefreshTokenModel RefreshToken(StravaApiRefreshTokenContract contract)
        {
            throw new NotImplementedException();
        }
    }
}
