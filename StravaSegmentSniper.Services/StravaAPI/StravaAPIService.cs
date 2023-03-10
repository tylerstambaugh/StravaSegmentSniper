using AutoMapper;
using Microsoft.Extensions.Configuration;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Athlete;
using StravaSegmentSniper.Services.StravaAPI.Models.Segment;
using StravaSegmentSniper.Services.StravaAPI.Models.Token;
using System.Configuration;
using System.Net.Http.Headers;

namespace StravaSegmentSniper.Services.StravaAPI
{
    public class StravaAPIService : IStravaAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public StravaAPIService(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<DetailedAthleteAPIModel> GetDetailedAthlete(string token)
        {
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = "api/v3/athlete"
            };

            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var url = builder.ToString();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode && response != null)
                {
                    DetailedAthleteAPIModel detailedAthleteFromApi = await response.Content.ReadAsAsync<DetailedAthleteAPIModel>();
                    return detailedAthleteFromApi;
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
        public async Task<List<SummaryActivityModel>> ViewAthleteActivity(int after, int before, string token)
        {
            string query = $"before={before}&after={after}&per_page=200";
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = "api/v3/athlete/activities",
                Query = query,
            };

            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var url = builder.ToString();

            try
            {

                HttpResponseMessage response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode && response != null)
                {
                    var apiResponseContent = await response.Content.ReadAsAsync<List<SummaryActivityAPIModel>>();

                    List<SummaryActivityModel> returnList = new List<SummaryActivityModel>();
                    foreach (SummaryActivityAPIModel s in apiResponseContent)
                    {
                        SummaryActivityModel model = _mapper
                            .Map<SummaryActivityAPIModel, SummaryActivityModel>(s);

                        returnList.Add(model);
                    }
                    return returnList;
                }
                else
                {
                    throw new Exception(response.Content.ToString());

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Staus Code{ex.StatusCode}, {ex.Message}");
                return null;
            }
        }

        public async Task<DetailedActivityAPIModel> GetDetailedActivityById(long activityId, string token)
        {
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = $"api/v3/activities/{activityId}",
                Query = "include_all_efforts=true"
            };

            _httpClient.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Bearer", token);

            var uri = builder.ToString();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    DetailedActivityAPIModel model = await response.Content
                        .ReadAsAsync<DetailedActivityAPIModel>();

                    return model;
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

        public async Task<List<DetailedSegmentEffortModel>> GetSegmentEffortsBySegmentId(int segmentId, DateTime startDate, DateTime endDate, string token)
        {
            var returnList = new List<DetailedSegmentEffortModel>();

            string query = $"segment_id={segmentId}&start_date_local={startDate}&end_date_local={endDate}";
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = $"api/v3/segment_efforts/",
                Query = query
            };

            _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", token);

            var uri = builder.ToString();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    List<DetailedSegmentEffortAPIModel> apiResponseContent = await response.Content
                        .ReadAsAsync<List<DetailedSegmentEffortAPIModel>>();

                    foreach (DetailedSegmentEffortAPIModel daam in apiResponseContent)
                    {
                        DetailedSegmentEffortModel model = _mapper
                            .Map<DetailedSegmentEffortAPIModel, DetailedSegmentEffortModel>(daam);
                        returnList.Add(model);
                    }
                    return returnList;
                }

                else
                {
                    throw new HttpRequestException(response.Content.ToString());
                }
            }

            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Staus Code{ex.StatusCode}, {ex.Message}");
                return null;
            }
        }

        public async Task<DetailedSegmentEffortModel> GetSegmentEffortById(string token, int segmentEffortId)
        {
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = $"api/v3/segment_efforts/{segmentEffortId}"
            };

            _httpClient.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Bearer", token);

            var uri = builder.ToString();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    DetailedSegmentEffortAPIModel apiResponseContent = await response.Content
                        .ReadAsAsync<DetailedSegmentEffortAPIModel>();

                    DetailedSegmentEffortModel model = _mapper
                        .Map<DetailedSegmentEffortAPIModel, DetailedSegmentEffortModel>(apiResponseContent);

                    return model;
                }
                else
                {
                    throw new HttpRequestException(response.Content.ToString());

                }
            }

            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Staus Code{ex.StatusCode}, {ex.Message}");
                return null;
            }
        }

        public async Task<DetailedSegmentModel> GetDetailedSegmentById(long segmentId, string token)
        {
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = $"api/v3/segments/{segmentId}"
            };

            _httpClient.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Bearer", token);

            var uri = builder.ToString();

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    DetailedSegmentAPIModel apiResponseContent = await response.Content
                        .ReadAsAsync<DetailedSegmentAPIModel>();

                    DetailedSegmentModel model = _mapper
                        .Map<DetailedSegmentAPIModel, DetailedSegmentModel>(apiResponseContent);
                    return model;
                }

                else
                {
                    throw new HttpRequestException(response.Content.ToString());
                }
            }

            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Staus Code{ex.StatusCode}, {ex.Message}");
                return null;
            }
        }


        public async Task<ActivityStatsModel> ViewAthleteStats(string token)
        {
            throw new NotImplementedException();
        }
        public async Task<Token> GetAthleteToken()
        {
            //https://www.strava.com/oauth/authorize?client_id=93654&redirect_uri=http://localhost&response_type=code&scope=activity:read_all&scope=read_all

            throw new NotImplementedException();
        }
        public async Task<RefreshTokenAPIModel> RefreshToken(string refreshToken)
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
                    var output = await response.Content.ReadAsAsync<RefreshTokenAPIModel>();
                    return output;
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


        //public async Task<T> GetAsync<T>(string url) where T : class
        //{
        //    //Generic GET call
        //    HttpResponseMessage response = await _httpClient.GetAsync(url);

        //    // if(response.IsS)
        //    return default;
        //}


        //Specific GET call
        //public async Task<LoggedInAthleteModel> GetLoggedInAthlete(string token)
        //{
        //    _httpClient.DefaultRequestHeaders.Authorization =
        //    new AuthenticationHeaderValue("Bearer", token);
        //    HttpResponseMessage response = await _httpClient.GetAsync("https://www.strava.com/api/v3/athlete");

        //    return (response.IsSuccessStatusCode && response.Content != null)
        //            ? await response.Content.ReadAsAsync<LoggedInAthleteModel>()
        //            : null;
        //}




        //public async Task<List<AthleteActivity>> GetAthleteActivity(string token)
        //{
        //    var u = "https://www.strava.com/api/v3/athlete/activities";

        //    var builder = new UriBuilder(u);
        //    builder.Query = "before=1672504919&after=1641055319";
        //    var url = builder.ToString();

        //    _httpClient.DefaultRequestHeaders.Authorization =
        //    new AuthenticationHeaderValue("Bearer", token);

        //    HttpResponseMessage response = await _httpClient.GetAsync(url);

        //    return (response.IsSuccessStatusCode && response.Content != null)
        //            ? await response.Content.ReadAsAsync<List<AthleteActivity>>()
        //            : null;


        //}

        //<T> is a placeholder for the Type that is passed in when the method is called.
        //public async Task<SearchResult<T>> GetSearchAsync<T>(string query, string category)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync($"https://swapi.dev/api/{category}/?search={query}");

        //    return response.IsSuccessStatusCode
        //        ? await response.Content.ReadAsAsync<SearchResult<T>>()
        //        : default;
        //}


        ////genericisizing the getSearchAsync
        //public async Task<SearchResult<Vehicle>> GetVehicleSearchAsync(string query)
        //{
        //    return await GetSearchAsync<Vehicle>(query, "vehicles");
        //}

    }
}
