using AutoMapper;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniperServices.Library.Internal.Models.Activity;
using StravaSegmentSniperServices.Library.Internal.Models.Segment;
using StravaSegmentSniperServices.Library.Internal.Models.Token;
using StravaSegmentSniperServices.Library.Internal.Services;
using StravaSegmentSniperServices.Library.StravaAPI.Models.Activity;
using StravaSegmentSniperServices.Library.StravaAPI.Models.Segment;
using System.Configuration;
using System.Net.Http.Headers;

namespace StravaSegmentSniperServices.Library.StravaAPI
{
    public class StravaAPIService : IStravaAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        // private readonly IConfiguration _configuration;

        public StravaAPIService(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            // _configuration = configuration;
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

        public async Task<DetailedActivityModel> GetDetailedActivityById(long activityId, string token)
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
                    DetailedActivityAPIModel apiResponseContent = await response.Content
                        .ReadAsAsync<DetailedActivityAPIModel>();

                    DetailedActivityModel model = _mapper
                        .Map<DetailedActivityAPIModel, DetailedActivityModel>(apiResponseContent);

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
        public async Task<RefreshTokenModel> RefreshToken(string refreshToken)
        {
            //refresh token
            //grant_type "refresh_token"
            string clientId = ConfigurationManager.AppSettings["StravaAPICodes:ClientId"];
            string clientSecret = ConfigurationManager.AppSettings["StravaAPICodes:ClientSecret"];


            string query = $"client_id={clientId}&client_secret={clientSecret}&refresh_token={refreshToken}&grant_type=refresh_token";
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = "oauth/token",
                Query = query
            };

            var url = builder.ToString();

            HttpResponseMessage response = await _httpClient.PostAsync(url, null);

            var output = await response.Content.ReadAsAsync<RefreshTokenModel>();

            return output;
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
