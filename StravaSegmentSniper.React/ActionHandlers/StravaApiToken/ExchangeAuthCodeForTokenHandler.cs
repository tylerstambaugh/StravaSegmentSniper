using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.TokenService;

namespace StravaSegmentSniper.React.ActionHandlers.StravaApiToken
{
    public class ExchangeAuthCodeForTokenHandler : IExchangeAuthCodeForTokenHandler
    {
        private readonly IStravaApiToken _stravaApiTokenService;
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStravaTokenService _stravaTokenService;

        public ExchangeAuthCodeForTokenHandler(IStravaApiToken stravaApiTokenService, IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor, IStravaTokenService stravaTokenService)
        {
            _stravaApiTokenService = stravaApiTokenService;
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
            _stravaTokenService = stravaTokenService;
        }
        public async Task<ExchangeAuthCodeForTokenContract.Result> Execute(ExchangeAuthCodeForTokenContract contract)
        {
            bool stravaAthleteIdWasAdded = false;
            bool tokenWasAdded = false;
            ValidateContract(contract);

            var tokenData = await _stravaApiTokenService.ExchangeAuthCodeForToken(contract.AuthCode);

            if (tokenData != null)
                try
                {
                    stravaAthleteIdWasAdded = _webAppUserService.AddStravaIdToWebAppUser(contract.UserId, tokenData.AthleteId);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("stravaAthleteId was not added", ex);
                }

            if (stravaAthleteIdWasAdded)
                try
                {
                    {
                        var stravaTokenToAdd = new Data.Entities.Token.StravaApiToken
                        {
                            UserId = contract.UserId,
                            AuthorizationToken = tokenData.Token,
                            RefreshToken = tokenData.RefreshToken,
                            ExpiresAt = tokenData.ExpiresAt,
                            ExpiresIn = tokenData.ExpiresIn,
                        };
                        tokenWasAdded = _stravaTokenService.AddStravaApiTokenRecord(stravaTokenToAdd);
                    } 
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("StravaApi token was not added", ex);
                }
            return new ExchangeAuthCodeForTokenContract.Result
            {
                TokenWasAdded = tokenWasAdded,
            };
        }

        private void ValidateContract(ExchangeAuthCodeForTokenContract contract)
            {
                if (contract == null)
                {
                    throw new ArgumentException("Invalid parameter", paramName: nameof(contract.AuthCode));
                }
            }
        }
    }
