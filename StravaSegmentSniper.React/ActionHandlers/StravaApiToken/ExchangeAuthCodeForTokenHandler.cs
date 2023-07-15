using Microsoft.AspNetCore.Authentication.JwtBearer;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.TokenService;
using System.Security.Claims;

namespace StravaSegmentSniper.React.ActionHandlers.StravaApiToken
{
    public class ExchangeAuthCodeForTokenHandler : IExchangeAuthCodeForTokenHandler
    {
        private readonly IStravaAPIToken _stravaApiTokenService;
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IStravaTokenService _stravaTokenService;

        public ExchangeAuthCodeForTokenHandler(IStravaAPIToken stravaApiTokenService, IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor, IStravaTokenService stravaTokenService)
        {
            _stravaApiTokenService = stravaApiTokenService;
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
            _stravaTokenService = stravaTokenService;
        }
        public async Task<ExchangeAuthCodeForTokenContract.Result> Execute(ExchangeAuthCodeForTokenContract contract)
        {
            ValidateContract(contract);

            //call stravaToken service to get token
            var tokenData =  await _stravaApiTokenService.ExchangeAuthCodeForToken(contract.AuthCode);


            //update webAppUser with StravaId

            //var auth = await _httpContextAccessor.HttpContext.Session.(JwtBearerDefaults.AuthenticationScheme);
            //if (auth.Succeeded)
            //{
            //    var claimsPrincipal = auth.Principal;
            //    var subject = claimsPrincipal.Claims.FirstOrDefault(a => a.Type == ClaimTypes.NameIdentifier).;
            //    // use the subject claim as needed (actual value is "subject.Value")
            //}

            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var userId = user.Id;
            var stravaAthleteIdWasAdded = _webAppUserService.AddStravaIdToWebAppUser(userId, tokenData.AthleteId);

            //update StravaApiTokens with tokendata
            var stravaTokenToAdd = new Data.Entities.Token.StravaApiToken
            {
                UserId = userId,
                DetailedAthleteId = tokenData.AthleteId,
                AuthorizationToken = tokenData.Token,
                RefreshToken = tokenData.RefreshToken,
                ExpiresAt = tokenData.ExpiresAt,
                ExpiresIn = tokenData.ExpiresIn,
            };

            var tokenWasAdded = _stravaTokenService.AddStravaApiTokenRecord(stravaTokenToAdd);

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
