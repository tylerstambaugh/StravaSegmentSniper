using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Token;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniper.Services.StravaAPI.TokenService;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class TokenService : ITokenService
    {
        private readonly StravaSegmentSniperDbContext _context;
        private readonly IStravaAPIToken _stravaAPIToken;

        public TokenService(StravaSegmentSniperDbContext context,
                            IStravaAPIToken stravaAPIToken)
        {
            _context = context;
            _stravaAPIToken = stravaAPIToken;
        }
        public Token GetTokenByStravaAthleteId(long stravaAthleteId)
        {
            return _context.Tokens.Where(x => x.User.Athlete.StravaAthleteId == stravaAthleteId).First();
        }

        public Token GetTokenByUserId(int userId)
        {
            if (TokenIsExpired(userId))
                RefreshToken(userId);            
            
            return _context.Tokens.Where(x => x.UserId == userId).First();
        }

        public bool TokenIsExpired(int userId)
        {
            Token tokenToCheck = _context.Tokens.Where(x => x.UserId == userId).First();
            DateTimeOffset expirationDate = DateTimeOffset.FromUnixTimeSeconds(tokenToCheck.ExpiresAt);

            return expirationDate < DateTimeOffset.UtcNow;
        }

        public int RefreshToken(int userId)
        {
            var tokenToUpdate = _context.Tokens
                        .Where(x => x.UserId == userId).First();

            RefreshTokenModel refreshedToken = _stravaAPIToken.RefreshToken(tokenToUpdate.RefreshToken).Result;

            if (refreshedToken.AccessToken != null)
            {
                try
                {
                    tokenToUpdate.RefreshToken = refreshedToken.RefreshToken;
                    tokenToUpdate.AuthorizationToken = refreshedToken.AccessToken;
                    tokenToUpdate.ExpiresIn = refreshedToken.ExpiresIn;
                    tokenToUpdate.ExpiresAt = refreshedToken.ExpiresAt;

                    return _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"an error occurred trying to update the token. {ex.Message} ");
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }



    }
}
