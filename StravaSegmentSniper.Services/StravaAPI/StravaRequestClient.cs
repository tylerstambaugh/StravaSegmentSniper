using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.StravaAPI
{
    internal class StravaRequestClient
    {
    }
}


//using Newtonsoft.Json;
//using SevenCorners.Esignature.Request.ZohoSign.Configuration;
//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace SevenCorners.Esignature.Request.ZohoSign
//{
//    internal class ZohoSignRequestClient : IZohoSignRequestClient
//    {
//        private readonly IZohoSignRequestServiceConfiguration _zohoSignRequestConfiguration;
//        private string _accessToken { get; set; }
//        private DateTime _tokenExpiration { get; set; }
//        private int _tokenExpirationBufferMinutes = 10;

//        private HttpMessageHandler _httpClientHandler { get; set; }
//        private HttpMessageHandler HttpClientHandler
//        {
//            get => _httpClientHandler ?? new HttpClientHandler();
//            set => _httpClientHandler = value;
//        }

//        public ZohoSignRequestClient(IZohoSignRequestServiceConfiguration zohoSignRequestClientConfiguration) : this(null, zohoSignRequestClientConfiguration)
//        {
//        }

//        internal ZohoSignRequestClient(HttpMessageHandler httpMessageHandler, IZohoSignRequestServiceConfiguration zohoSignRequestConfiguration)
//        {
//            _httpClientHandler = httpMessageHandler;
//            _zohoSignRequestConfiguration = zohoSignRequestConfiguration;
//        }

//        public async Task<TResponse> GetAsync<TResponse>(string url) where TResponse : class
//        {
//            if (!TokenIsValid())
//            {
//                await GetRefreshToken();
//            }

//            TResponse result = null;
//            using (var httpClient = new HttpClient(HttpClientHandler))
//            {
//                ConfigureHttpClient(httpClient);

//                var response = await httpClient.GetAsync(url);

//                await VerifyResponse(response);

//                var stringResult = await response.Content.ReadAsStringAsync();
//                result = JsonConvert.DeserializeObject<TResponse>(stringResult);
//            }

//            return result;
//        }

//        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data) where TResponse : class
//        {
//            var serializedData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
//            return await Post<TResponse>(url, serializedData);
//        }

//        public async Task<TResponse> PostAsync<TResponse>(string url) where TResponse : class
//        {
//            return await Post<TResponse>(url, null);
//        }

//        private async Task<TResponse> Post<TResponse>(string url, StringContent data) where TResponse : class
//        {
//            if (!TokenIsValid())
//            {
//                await GetRefreshToken();
//            }

//            TResponse result = null;
//            using (var httpClient = new HttpClient(HttpClientHandler))
//            {
//                ConfigureHttpClient(httpClient);

//                var response = await httpClient.PostAsync(url, data);

//                await VerifyResponse(response);

//                var stringResult = await response.Content.ReadAsStringAsync();
//                result = JsonConvert.DeserializeObject<TResponse>(stringResult);
//            }
//            return result;
//        }

//        public async Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest data) where TResponse : class
//        {
//            if (!TokenIsValid())
//            {
//                await GetRefreshToken();
//            }

//            TResponse result = null;
//            using (var httpClient = new HttpClient(HttpClientHandler))
//            {

//                ConfigureHttpClient(httpClient);

//                if (!(data is HttpContent content))
//                {
//                    var jsonRequest = JsonConvert.SerializeObject(data);
//                    content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
//                }

//                var response = await httpClient.PutAsync(url, content);
//                await VerifyResponse(response);

//                var stringResult = await response.Content.ReadAsStringAsync();
//                result = JsonConvert.DeserializeObject<TResponse>(stringResult);
//            }
//            return result;

//        }

//        private void ConfigureHttpClient(HttpClient httpClient)
//        {
//            httpClient.BaseAddress = new Uri(_zohoSignRequestConfiguration.BaseUrl);
//            httpClient.DefaultRequestHeaders.Accept.Clear();
//            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", _accessToken);
//        }

//        private static async Task VerifyResponse(HttpResponseMessage response)
//        {
//            if (!response.IsSuccessStatusCode)
//            {
//                var error = await response.Content.ReadAsStringAsync();

//                if (error.Contains("message"))
//                {
//                    var errorObject = JsonConvert.DeserializeAnonymousType(error, new { message = "" });
//                    throw new HttpRequestException($"{response.StatusCode}: {errorObject.message}");
//                }
//                else if (!string.IsNullOrWhiteSpace(error))
//                {
//                    throw new HttpRequestException($"{response.StatusCode}: {error}");
//                }
//                else
//                {
//                    response.EnsureSuccessStatusCode();
//                }
//            }
//        }

//        private bool TokenIsValid()
//        {
//            return _accessToken != null
//                && DateTime.Now.Subtract(TimeSpan.FromMinutes(_tokenExpirationBufferMinutes)) < _tokenExpiration;
//        }

//        private async Task GetRefreshToken()
//        {
//            using (var httpClient = new HttpClient(HttpClientHandler))
//            {
//                httpClient.BaseAddress = new Uri(_zohoSignRequestConfiguration.AccountBaseUrl);
//                httpClient.DefaultRequestHeaders.Accept.Clear();
//                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                var query = $"refresh_token={_zohoSignRequestConfiguration.RefreshToken}&client_id={_zohoSignRequestConfiguration.ClientId}&client_secret={_zohoSignRequestConfiguration.ClientSecret}&grant_type=refresh_token";



//                var response = await httpClient.PostAsync($"token?{query}", null);

//                await VerifyResponse(response);

//                var stringResult = await response.Content.ReadAsStringAsync();
//                var result = JsonConvert.DeserializeObject<RefreshTokenResponse>(stringResult);

//                _accessToken = result.AccessToken;
//                _tokenExpiration = DateTime.Now.AddSeconds(result.ExpiresIn);
//            }
//        }

//        private class RefreshTokenResponse
//        {
//            [JsonProperty("access_token")]
//            public string AccessToken { get; set; }
//            [JsonProperty("api_domain")]
//            public string ApiDomain { get; set; }
//            [JsonProperty("token_type")]
//            public string TokenType { get; set; }
//            [JsonProperty("expires_in")]
//            public int ExpiresIn { get; set; }
//        }
//    }
//}
//using Newtonsoft.Json;
//using SevenCorners.Esignature.Request.ZohoSign.Configuration;
//using System;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Threading.Tasks;

//namespace SevenCorners.Esignature.Request.ZohoSign
//{
//    internal class ZohoSignRequestClient : IZohoSignRequestClient
//    {
//        private readonly IZohoSignRequestServiceConfiguration _zohoSignRequestConfiguration;
//        private string _accessToken { get; set; }
//        private DateTime _tokenExpiration { get; set; }
//        private int _tokenExpirationBufferMinutes = 10;

//        private HttpMessageHandler _httpClientHandler { get; set; }
//        private HttpMessageHandler HttpClientHandler
//        {
//            get => _httpClientHandler ?? new HttpClientHandler();
//            set => _httpClientHandler = value;
//        }

//        public ZohoSignRequestClient(IZohoSignRequestServiceConfiguration zohoSignRequestClientConfiguration) : this(null, zohoSignRequestClientConfiguration)
//        {
//        }

//        internal ZohoSignRequestClient(HttpMessageHandler httpMessageHandler, IZohoSignRequestServiceConfiguration zohoSignRequestConfiguration)
//        {
//            _httpClientHandler = httpMessageHandler;
//            _zohoSignRequestConfiguration = zohoSignRequestConfiguration;
//        }

//        public async Task<TResponse> GetAsync<TResponse>(string url) where TResponse : class
//        {
//            if (!TokenIsValid())
//            {
//                await GetRefreshToken();
//            }

//            TResponse result = null;
//            using (var httpClient = new HttpClient(HttpClientHandler))
//            {
//                ConfigureHttpClient(httpClient);

//                var response = await httpClient.GetAsync(url);

//                await VerifyResponse(response);

//                var stringResult = await response.Content.ReadAsStringAsync();
//                result = JsonConvert.DeserializeObject<TResponse>(stringResult);
//            }

//            return result;
//        }

//        public async Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data) where TResponse : class
//        {
//            var serializedData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
//            return await Post<TResponse>(url, serializedData);
//        }

//        public async Task<TResponse> PostAsync<TResponse>(string url) where TResponse : class
//        {
//            return await Post<TResponse>(url, null);
//        }

//        private async Task<TResponse> Post<TResponse>(string url, StringContent data) where TResponse : class
//        {
//            if (!TokenIsValid())
//            {
//                await GetRefreshToken();
//            }

//            TResponse result = null;
//            using (var httpClient = new HttpClient(HttpClientHandler))
//            {
//                ConfigureHttpClient(httpClient);

//                var response = await httpClient.PostAsync(url, data);

//                await VerifyResponse(response);

//                var stringResult = await response.Content.ReadAsStringAsync();
//                result = JsonConvert.DeserializeObject<TResponse>(stringResult);
//            }
//            return result;
//        }

//        public async Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest data) where TResponse : class
//        {
//            if (!TokenIsValid())
//            {
//                await GetRefreshToken();
//            }

//            TResponse result = null;
//            using (var httpClient = new HttpClient(HttpClientHandler))
//            {

//                ConfigureHttpClient(httpClient);

//                if (!(data is HttpContent content))
//                {
//                    var jsonRequest = JsonConvert.SerializeObject(data);
//                    content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
//                }

//                var response = await httpClient.PutAsync(url, content);
//                await VerifyResponse(response);

//                var stringResult = await response.Content.ReadAsStringAsync();
//                result = JsonConvert.DeserializeObject<TResponse>(stringResult);
//            }
//            return result;

//        }

//        private void ConfigureHttpClient(HttpClient httpClient)
//        {
//            httpClient.BaseAddress = new Uri(_zohoSignRequestConfiguration.BaseUrl);
//            httpClient.DefaultRequestHeaders.Accept.Clear();
//            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Zoho-oauthtoken", _accessToken);
//        }

//        private static async Task VerifyResponse(HttpResponseMessage response)
//        {
//            if (!response.IsSuccessStatusCode)
//            {
//                var error = await response.Content.ReadAsStringAsync();

//                if (error.Contains("message"))
//                {
//                    var errorObject = JsonConvert.DeserializeAnonymousType(error, new { message = "" });
//                    throw new HttpRequestException($"{response.StatusCode}: {errorObject.message}");
//                }
//                else if (!string.IsNullOrWhiteSpace(error))
//                {
//                    throw new HttpRequestException($"{response.StatusCode}: {error}");
//                }
//                else
//                {
//                    response.EnsureSuccessStatusCode();
//                }
//            }
//        }

//        private bool TokenIsValid()
//        {
//            return _accessToken != null
//                && DateTime.Now.Subtract(TimeSpan.FromMinutes(_tokenExpirationBufferMinutes)) < _tokenExpiration;
//        }

//        private async Task GetRefreshToken()
//        {
//            using (var httpClient = new HttpClient(HttpClientHandler))
//            {
//                httpClient.BaseAddress = new Uri(_zohoSignRequestConfiguration.AccountBaseUrl);
//                httpClient.DefaultRequestHeaders.Accept.Clear();
//                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//                var query = $"refresh_token={_zohoSignRequestConfiguration.RefreshToken}&client_id={_zohoSignRequestConfiguration.ClientId}&client_secret={_zohoSignRequestConfiguration.ClientSecret}&grant_type=refresh_token";



//                var response = await httpClient.PostAsync($"token?{query}", null);

//                await VerifyResponse(response);

//                var stringResult = await response.Content.ReadAsStringAsync();
//                var result = JsonConvert.DeserializeObject<RefreshTokenResponse>(stringResult);

//                _accessToken = result.AccessToken;
//                _tokenExpiration = DateTime.Now.AddSeconds(result.ExpiresIn);
//            }
//        }

//        private class RefreshTokenResponse
//        {
//            [JsonProperty("access_token")]
//            public string AccessToken { get; set; }
//            [JsonProperty("api_domain")]
//            public string ApiDomain { get; set; }
//            [JsonProperty("token_type")]
//            public string TokenType { get; set; }
//            [JsonProperty("expires_in")]
//            public int ExpiresIn { get; set; }
//        }
//    }
//}
