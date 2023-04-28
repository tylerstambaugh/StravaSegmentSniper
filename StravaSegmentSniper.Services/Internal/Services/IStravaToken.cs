using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IStravaToken
    {
        StravaApiToken GetTokenByStravaAthleteId(long stravaAthleteId);
        StravaApiToken GetTokenByUserId(string userId);
        int RefreshToken(string userId);
        bool TokenIsExpired(string userId);
    }
}