using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Token;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IStravaTokenService
    {
        StravaApiToken GetTokenByUserId(string userId);
        int RefreshToken(string userId);
        bool TokenIsExpired(string userId);
        StravaApiTokenModel GetCurrentStravaApiToken(string userId);
        bool AddStravaApiTokenRecord(StravaApiToken model);
    }
}