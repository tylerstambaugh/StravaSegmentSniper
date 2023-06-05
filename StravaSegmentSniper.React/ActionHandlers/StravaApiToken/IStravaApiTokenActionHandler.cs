using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Token;

namespace StravaSegmentSniper.React.ActionHandlers.StravaApiToken
{
    public interface IStravaApiTokenActionHandler
    {
        StravaApiTokenModel GetCurrentStravaApiToken();
        RefreshTokenModel RefreshToken(StravaApiRefreshTokenContract contract);
    }
}