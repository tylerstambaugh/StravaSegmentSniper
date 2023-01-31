using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniperServices.Library.Internal.Models.Activity;
using StravaSegmentSniperServices.Library.Internal.Models.Segment;
using StravaSegmentSniperServices.Library.Internal.Models.Token;

namespace StravaSegmentSniperServices.Library.StravaAPI
{
    public interface IStravaAPIService
    {
        Task<Token> GetAthleteToken();
        Task<DetailedActivityModel> GetDetailedActivityById(long activityId, string token);
        Task<DetailedSegmentModel> GetDetailedSegmentById(long segmentId, string token);
        Task<DetailedSegmentEffortModel> GetSegmentEffortById(string token, int segmentEffortId);
        Task<List<DetailedSegmentEffortModel>> GetSegmentEffortsBySegmentId(int segmentId, DateTime startDate, DateTime endDate, string token);
        Task<RefreshTokenModel> RefreshToken(string refreshToken);
        Task<List<SummaryActivityModel>> ViewAthleteActivity(int after, int before, string token);
        Task<ActivityStatsModel> ViewAthleteStats(string token);
    }
}