using AutoMapper;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.StravaAPI.Activity
{
    public class StravaAPIActivity
    {
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient = new HttpClient();

        public StravaAPIActivity(IMapper mapper)
        {
            _mapper = mapper;
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
    }
}
