using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface ITokenService
    {
        Token GetTokenByStravaAthleteId(long stravaAthleteId);
        Token GetTokenByUserId(int userId);
        Token RefreshToken(string refreshToken, long athleteId);
        bool TokenIsExpired(long stravaAthleteId);
    }
}