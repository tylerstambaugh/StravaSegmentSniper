using StravaSegmentSniper.Data.Entities;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniper.Services.StravaAPI.Models.Token;
using StravaSegmentSniperReact.Data;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class TokenService : ITokenService
    {
        private readonly StravaSegmentSniperDbContext _context;
        private readonly IStravaAPIService _stravaAPIService;

        public TokenService(StravaSegmentSniperDbContext context, IStravaAPIService stravaAPIService)
        {
            _context = context;
            _stravaAPIService = stravaAPIService;
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

            RefreshTokenAPIModel refreshedToken = _stravaAPIService.RefreshToken(tokenToUpdate.RefreshToken).Result;

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
