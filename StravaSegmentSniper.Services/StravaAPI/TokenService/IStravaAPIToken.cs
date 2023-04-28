using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Token;

namespace StravaSegmentSniper.Services.StravaAPI.TokenService
{
    public interface IStravaAPIToken
    {
        Task<StravaApiToken> GetAthleteToken();
        Task<RefreshTokenModel> RefreshToken(string refreshToken);
    }
}