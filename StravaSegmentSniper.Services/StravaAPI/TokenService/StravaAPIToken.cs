using AutoMapper;
using Microsoft.Extensions.Configuration;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Token;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Token;

namespace StravaSegmentSniper.Services.StravaAPI.TokenService
{
    public class StravaAPIToken : IStravaAPIToken
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient = new HttpClient();
        public StravaAPIToken(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<StravaApiToken> GetAthleteToken()
        {
            //https://www.strava.com/oauth/authorize?client_id=93654&redirect_uri=http://localhost&response_type=code&scope=activity:read_all&scope=read_all

            throw new NotImplementedException();
        }
        public async Task<RefreshTokenModel> RefreshToken(string refreshToken)
        {
            //refresh token
            //grant_type "refresh_token"
            var clientId = _configuration.GetSection("StravaAPICodes:ClientId");
            var clientSecret = _configuration.GetSection("StravaAPICodes:ClientSecret");

            string query = $"client_id={clientId.Value}&client_secret={clientSecret.Value}&refresh_token={refreshToken}&grant_type=refresh_token";
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = "oauth/token",
                Query = query
            };

            var url = builder.ToString();

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(url, null);
                if (response.IsSuccessStatusCode)
                {
                    var model = await response.Content.ReadAsAsync<RefreshTokenAPIModel>();

                    RefreshTokenModel returnToken = _mapper
                              .Map<RefreshTokenAPIModel, RefreshTokenModel>(model);

                    return returnToken;
                }
                else
                {
                    throw new HttpRequestException(response.Content.ToString());
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Status Code{ex.StatusCode}, {ex.Message}");
                return null;
            }
        }

    }
}
