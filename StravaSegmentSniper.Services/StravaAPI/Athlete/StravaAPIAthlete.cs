using AutoMapper;
using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Models.Athlete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.StravaAPI.Athlete
{
    public class StravaAPIAthlete : IStravaAPIAthlete
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient = new HttpClient();

        public StravaAPIAthlete(ITokenService tokenService,
                                IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<DetailedAthleteModel> GetDetailedAthleteFromStrava(int userId)
        {
            var token = _tokenService.GetTokenByUserId(userId);
            if (token != null)
            {
                var builder = new UriBuilder()
                {
                    Scheme = "https",
                    Host = "www.strava.com",
                    Path = "api/v3/athlete"
                };

                _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", token.AuthorizationToken);

                var url = builder.ToString();

                try
                {
                    HttpResponseMessage response = await _httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode && response != null)
                    {
                        DetailedAthleteAPIModel detailedAthleteFromApi = await response.Content.ReadAsAsync<DetailedAthleteAPIModel>();

                        DetailedAthleteModel model = _mapper
                           .Map<DetailedAthleteAPIModel, DetailedAthleteModel>(detailedAthleteFromApi);
                        return model;
                    }
                    else
                    {
                        throw new Exception(response.Content.ToString());
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Status Code{ex.StatusCode}, {ex.Message}");
                    return null;
                }
            }
            else
            {
                throw new ArgumentException("invalid user id");
            }
        }
    }
}

