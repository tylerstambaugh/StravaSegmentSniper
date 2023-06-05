using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.Activity.Contracts;
using StravaSegmentSniper.React.ActionHandlers.StravaApiToken;
using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Token;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StravaApiTokenController : ControllerBase
    {
        private readonly IStravaApiTokenActionHandler _stravaApiTokenActionHandler;

        public StravaApiTokenController(IStravaApiTokenActionHandler stravaApiTokenActionHandler)
        {
            _stravaApiTokenActionHandler = stravaApiTokenActionHandler;
        }

        [HttpGet]
        [ActionName("RefreshStravaApiToken")]
        public RefreshTokenModel RefreshStravaApiToken(string refreshToken)
        {
            StravaApiRefreshTokenContract contract = new StravaApiRefreshTokenContract
            {
               RefreshToken = refreshToken
            };

            var refreshedTokenData = _stravaApiTokenActionHandler.RefreshToken(contract);

            return refreshedTokenData;

        }


    }

}
