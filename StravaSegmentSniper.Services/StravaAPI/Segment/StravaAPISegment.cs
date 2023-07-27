using AutoMapper;
using Newtonsoft.Json;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Models.Segment;
using System.Net.Http.Headers;
using System.Text;

namespace StravaSegmentSniper.Services.StravaAPI.Segment
{
    public class StravaApiSegment : IStravaApiSegment
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IMapper _mapper;
        private readonly IStravaTokenService _tokenService;

        public StravaApiSegment(IMapper mapper, IStravaTokenService tokenService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<DetailedSegmentModel> GetDetailedSegmentById(long segmentId, string userId)
        {
            string token = _tokenService.GetTokenByUserId(userId).AuthorizationToken;
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
                    DetailedSegmentApiModel apiResponseContent = await response.Content
                        .ReadAsAsync<DetailedSegmentApiModel>();

                    DetailedSegmentModel model = _mapper
                        .Map<DetailedSegmentApiModel, DetailedSegmentModel>(apiResponseContent);
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

        public async Task<List<DetailedSegmentEffortModel>> GetSegmentEffortsBySegmentId(int segmentId, DateTime startDate, DateTime endDate, string userId)
        {
            string token = _tokenService.GetTokenByUserId(userId).AuthorizationToken;
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
                    List<DetailedSegmentEffortApiModel> apiResponseContent = await response.Content
                        .ReadAsAsync<List<DetailedSegmentEffortApiModel>>();

                    foreach (DetailedSegmentEffortApiModel daam in apiResponseContent)
                    {
                        DetailedSegmentEffortModel model = _mapper
                            .Map<DetailedSegmentEffortApiModel, DetailedSegmentEffortModel>(daam);
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

        public async Task<DetailedSegmentEffortModel> GetSegmentEffortById(string userId, int segmentEffortId)
        {
            string token = _tokenService.GetTokenByUserId(userId).AuthorizationToken;
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
                    DetailedSegmentEffortApiModel apiResponseContent = await response.Content
                        .ReadAsAsync<DetailedSegmentEffortApiModel>();

                    DetailedSegmentEffortModel model = _mapper
                        .Map<DetailedSegmentEffortApiModel, DetailedSegmentEffortModel>(apiResponseContent);

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

        public async Task<DetailedSegmentModel> StarSegment(StarSegmentModel request)
        {
            string token = _tokenService.GetTokenByUserId(request.UserId).AuthorizationToken;
            var builder = new UriBuilder()
            {
                Scheme = "https",
                Host = "www.strava.com",
                Path = $"api/v3//segments/{request.SegmentId}/starred"
            };

            _httpClient.DefaultRequestHeaders.Authorization =
           new AuthenticationHeaderValue("Bearer", token);

            var uri = builder.ToString();
            //var stringContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8, "application/json");

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("starred", request.IsStarred.ToString()) 
            });

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(uri, formContent);
                if (response.IsSuccessStatusCode)
                {
                    DetailedSegmentApiModel apiResponseContent = await response.Content
                        .ReadAsAsync<DetailedSegmentApiModel>();

        DetailedSegmentModel model = _mapper
            .Map<DetailedSegmentApiModel, DetailedSegmentModel>(apiResponseContent);

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
    }
}
