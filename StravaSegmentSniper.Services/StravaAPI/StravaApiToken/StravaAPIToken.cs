using AutoMapper;
using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Token;
using StravaSegmentSniper.Services.StravaAPI.Models.Token;
using static IdentityModel.OidcConstants;
using System.Security.Policy;

namespace StravaSegmentSniper.Services.StravaAPI.TokenService
{
    public class StravaApiToken : IStravaApiToken
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _clientId;
        private readonly string _clientSecret;

        public StravaApiToken(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
            _clientId = _configuration.GetSection("StravaAPICodes:ClientId").Value;
            _clientSecret = _configuration.GetSection("StravaAPICodes:ClientSecret").Value;
        }

        public async Task<StravaApiTokenModel> ExchangeAuthCodeForToken(string authCode)
        {

            string query = $"client_id={_clientId}&client_secret={_clientSecret}&code={authCode}&grant_type=authorization_code";
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
                    var model = await response.Content.ReadAsAsync<StravaApiExchangeTokenResponse>();

                    StravaApiTokenModel returnToken = _mapper
                              .Map<StravaApiExchangeTokenResponse, StravaApiTokenModel>(model);

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

            throw new NotImplementedException();
        }

        public async Task<RefreshTokenModel> RefreshToken(string refreshToken)
        {
            string query = $"client_id={_clientId}&client_secret={_clientSecret}&refresh_token={refreshToken}&grant_type=refresh_token";
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
