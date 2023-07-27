namespace StravaSegmentSniper.Services.StravaAPI
{
    internal interface IStravaApiRequestClient
    {
        Task<TResponse> GetAsync<TResponse>(string url) where TResponse : class;
        Task<TResponse> PostAsync<TRequest, TResponse>(string url, TRequest data) where TResponse : class;
        Task<TResponse> PostAsync<TResponse>(string url) where TResponse : class;
        Task<TResponse> PutAsync<TRequest, TResponse>(string url, TRequest data) where TResponse : class;
    }
}