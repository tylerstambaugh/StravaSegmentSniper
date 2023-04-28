using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface ITokenService
    {
        StravaApiToken GetTokenByStravaAthleteId(long stravaAthleteId);
        StravaApiToken GetTokenByUserId(int userId);
        int RefreshToken(int userId);
        bool TokenIsExpired(int userId);
    }
}