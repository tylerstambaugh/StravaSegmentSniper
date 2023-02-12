using StravaSegmentSniper.Data.Entities;
using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class TokenService : ITokenService
    {
        private readonly IStravaSegmentSniperDBContext _context;

        public TokenService(IStravaSegmentSniperDBContext context)
        {
            _context = context;
        }
        public Token GetTokenByStravaAthleteId(long stravaAthleteId)
        {
            return _context.Tokens.Where(x => x.User.Athlete.StravaAthleteId == stravaAthleteId).First();
        }

        public Token GetTokenByUserId(int userId)
        {
            return _context.Tokens.Where(x => x.UserId == userId).First();
        }

        public Token RefreshToken(string refreshToken, long athleteId)
        {
            Token newToken = new Token();
            // RefreshTokenModel refreshedToken = _stravaAPIService.RefreshToken(refreshToken).Result;

            //newToken.RefreshToken = refreshedToken.RefreshToken;
            //newToken.Token = refreshedToken.AccessToken;
            //newToken.AthleteId = athleteId;
            //newToken.ExpiresIn = refreshedToken.ExpiresIn;
            //newToken.ExpiresAt = refreshedToken.ExpiresAt;

            //var result = _tokenData.UpdateToken(newToken);

            //if(result == 1)
            //{
            //    return GetTokenByAthleteId(athleteId);
            //}
            //else
            //{
            //    return null;
            //}
            return null;

        }

        public bool TokenIsExpired(long stravaAthleteId)
        {
            Token tokenToCheck = GetTokenByStravaAthleteId(stravaAthleteId);
            DateTimeOffset expirationDate = DateTimeOffset.FromUnixTimeSeconds(tokenToCheck.ExpiresAt);

            return expirationDate < DateTimeOffset.UtcNow;
        }

    }
}
