using AutoMapper;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Models.Segment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.StravaAPI.Segment
{
    public class StravaAPISegment : IStravaAPISegment
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly IMapper _mapper;
        private readonly IStravaToken _tokenService;

        public StravaAPISegment(IMapper mapper, IStravaToken tokenService)
        {
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<DetailedSegmentModel> GetDetailedSegmentById(long segmentId, int userId)
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

        public async Task<List<DetailedSegmentEffortModel>> GetSegmentEffortsBySegmentId(int segmentId, DateTime startDate, DateTime endDate, int userId)
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

        public async Task<DetailedSegmentEffortModel> GetSegmentEffortById(int userId, int segmentEffortId)
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
    }
}
