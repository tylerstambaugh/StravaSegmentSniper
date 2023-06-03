using Authorization.Data.Data;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Token;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniper.Services.StravaAPI.TokenService;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class StravaTokenService : IStravaToken
    {
        private readonly StravaSegmentSniperDbContext _context;
        private readonly AuthDbContext _authDbContext;
        private readonly IStravaAPIToken _stravaAPIToken;

        public StravaTokenService(StravaSegmentSniperDbContext context,
                            IStravaAPIToken stravaAPIToken, AuthDbContext authDbContext)
        {
            _context = context;
            _stravaAPIToken = stravaAPIToken;
            _authDbContext = authDbContext;
        }
        public StravaApiToken GetTokenByStravaAthleteId(long stravaAthleteId)
        {
            string userId = _authDbContext.Users.Where(x => x.StravaAthleteId == stravaAthleteId).First().Id;
           
            if (TokenIsExpired(userId))
                RefreshToken(userId);

            return _context.StravaApiTokens.Where(x => x.Athlete.StravaAthleteId == stravaAthleteId).First();
        }

        public StravaApiToken GetTokenByUserId(string userId)
        {
            if (TokenIsExpired(userId))
                RefreshToken(userId);

            return _context.StravaApiTokens.Where(x => x.UserId == userId).First();
        }

        public bool TokenIsExpired(string userId)
        {
            var tokenToCheck = _context.StravaApiTokens.Where(x => x.UserId == userId).First();
            DateTimeOffset expirationDate = DateTimeOffset.FromUnixTimeSeconds(tokenToCheck.ExpiresAt);

            return expirationDate < DateTimeOffset.Now;
        }

        public int RefreshToken(string userId)
        {
            var tokenToUpdate = _context.StravaApiTokens
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
