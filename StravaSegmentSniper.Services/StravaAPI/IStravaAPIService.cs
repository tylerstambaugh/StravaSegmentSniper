using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Models.Token;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Athlete;

namespace StravaSegmentSniper.Services.StravaAPI
{
    public interface IStravaAPIService
    {
        Task<Token> GetAthleteToken();
        Task<DetailedAthleteAPIModel> GetDetailedAthlete(string token);
        Task<DetailedActivityAPIModel> GetDetailedActivityById(long activityId, string token);
        Task<DetailedSegmentModel> GetDetailedSegmentById(long segmentId, string token);
        Task<DetailedSegmentEffortModel> GetSegmentEffortById(string token, int segmentEffortId);
        Task<List<DetailedSegmentEffortModel>> GetSegmentEffortsBySegmentId(int segmentId, DateTime startDate, DateTime endDate, string token);
        Task<RefreshTokenModel> RefreshToken(string refreshToken);
        Task<List<SummaryActivityModel>> ViewAthleteActivity(int after, int before, string token);
        Task<ActivityStatsModel> ViewAthleteStats(string token);
    }
}