using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniperServices.Library.Internal.Services
{
    public interface ITokenService
    {
        Token GetTokenByStravaAthleteId(long stravaAthleteId);
        Token RefreshToken(string refreshToken, long athleteId);
        bool TokenIsExpired(long stravaAthleteId);
    }
}