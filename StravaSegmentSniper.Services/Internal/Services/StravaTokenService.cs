using Authorization.Data.Data;
using AutoMapper;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Services.Internal.Models.Token;
using StravaSegmentSniper.Services.StravaAPI.TokenService;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class StravaTokenService : IStravaTokenService
    {
        private readonly StravaSegmentSniperDbContext _context;
        private readonly IMapper _mapper;
        private readonly IStravaApiToken _stravaAPIToken;
        private Data.Entities.Token.StravaApiToken _token;

        public StravaTokenService(StravaSegmentSniperDbContext context,
                            IStravaApiToken stravaAPIToken, IMapper mapper)
        {
            _context = context;
            _stravaAPIToken = stravaAPIToken;
            _mapper = mapper;
        }

        public Data.Entities.Token.StravaApiToken GetTokenByUserId(string userId)
        {
            if (_token == null)
            {
                _token = _context.StravaApiTokens.Where(x => x.UserId == userId).First();
            }
            if (!TokenIsExpired(_token))
            {
                return _token;
            }
            else {
                RefreshToken(userId);
                _token = _context.StravaApiTokens.Where(x => x.UserId == userId).First();

                return _token;
            }
        }

        public bool TokenIsExpired(Data.Entities.Token.StravaApiToken token)
        {
            
            DateTimeOffset expirationDate = DateTimeOffset.FromUnixTimeSeconds(token.ExpiresAt);
            return expirationDate < DateTimeOffset.Now;
        }

        public int RefreshToken(string userId)
        {
            var tokenToUpdate = _context.StravaApiTokens
                        .Where(x => x.UserId == userId).First();

            RefreshTokenModel refreshedToken = _stravaAPIToken.RefreshToken(tokenToUpdate.RefreshToken).Result;

            if (refreshedToken.AccessToken != null && refreshedToken != null)
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
        public StravaApiTokenModel GetCurrentStravaApiToken(string userId)
        {
            var currentToken = _context.StravaApiTokens.Where(x => x.UserId == userId).First();

            StravaApiTokenModel model = _mapper.Map<Data.Entities.Token.StravaApiToken, StravaApiTokenModel>(currentToken);

            return model;
        }

        public bool AddStravaApiTokenRecord(Data.Entities.Token.StravaApiToken model)
        {
            var existingRecord = _context.StravaApiTokens.Where(t => t.UserId == model.UserId).FirstOrDefault();

            if (existingRecord != null)
            {
                existingRecord.RefreshToken = model.RefreshToken;
                existingRecord.AuthorizationToken = model.AuthorizationToken;
                existingRecord.ExpiresIn = model.ExpiresIn;
                existingRecord.ExpiresAt = model.ExpiresAt;
            }
            else
            {
                _context.StravaApiTokens.Add(model);
            }
            return _context.SaveChanges() == 1;
        }

    }
}
