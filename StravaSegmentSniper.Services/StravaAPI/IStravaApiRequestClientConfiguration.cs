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
        string BaseUrl { get; }
        string AccountBaseUrl { get; }
    }
}


//namespace SevenCorners.Esignature.Request.ZohoSign.Configuration
//{
//    public interface IZohoSignRequestServiceConfiguration
//    {
//        string ClientId { get; }
//        string ClientSecret { get; }
//        string RefreshToken { get; }
//        string BaseUrl { get; }
//        string AccountBaseUrl { get; }
//        string SignSuccessUrl { get; }
//        string SignDeclinedUrl { get; }
//        string SignLaterUrl { get; }
//        string SignCompletedUrl { get; }
//        string HostedDomainUrl { get; }
//    }
//}