using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.StravaAPI
{
    public interface IStravaApiRequestClientConfiguration
    {
        string ClientId { get; }
        string ClientSecret { get; }
        string RefreshToken { get; }
        string AccessToken { get; }
        string BaseUrl { get; }
        string AccountBaseUrl { get; }
    }
}
