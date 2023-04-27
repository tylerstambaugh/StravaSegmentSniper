using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.Services.StravaAPI.Segment
{
    public interface IStravaAPISegment
    {
        Task<DetailedSegmentModel> GetDetailedSegmentById(long segmentId, long stravaAthleteId);
        Task<DetailedSegmentEffortModel> GetSegmentEffortById(long stravaAthleteId, int segmentEffortId);
        Task<List<DetailedSegmentEffortModel>> GetSegmentEffortsBySegmentId(int segmentId, DateTime startDate, DateTime endDate, long stravaAthleteId);
    }
}