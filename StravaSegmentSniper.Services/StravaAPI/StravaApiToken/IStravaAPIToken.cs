using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Token;

namespace StravaSegmentSniper.Services.StravaAPI.TokenService
{
    public interface IStravaApiToken
    {
        Task<StravaApiTokenModel> ExchangeAuthCodeForToken(string authCode);
        Task<RefreshTokenModel> RefreshToken(string refreshToken);
    }
}