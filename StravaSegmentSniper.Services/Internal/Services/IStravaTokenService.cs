using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Token;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IStravaTokenService
    {
        StravaApiToken GetTokenByStravaAthleteId(long stravaAthleteId);
        StravaApiToken GetTokenByUserId(string userId);
        int RefreshToken(string userId);
        bool TokenIsExpired(string userId);
        StravaApiTokenModel GetCurrentStravaApiToken(string userId);
    }
}