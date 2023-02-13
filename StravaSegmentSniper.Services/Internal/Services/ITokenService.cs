using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface ITokenService
    {
        Token GetTokenByStravaAthleteId(long stravaAthleteId);
        Token GetTokenByUserId(int userId);
        int RefreshToken(int userId);
        bool TokenIsExpired(int userId);
    }
}