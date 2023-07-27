using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.Services.StravaAPI.Segment
{
    public interface IStravaApiSegment
    {
        Task<DetailedSegmentModel> GetDetailedSegmentById(long segmentId, string userId);
        Task<DetailedSegmentEffortModel> GetSegmentEffortById(string userId, int segmentEffortId);
        Task<List<DetailedSegmentEffortModel>> GetSegmentEffortsBySegmentId(int segmentId, DateTime startDate, DateTime endDate, string userId);

        Task<DetailedSegmentModel> StarSegment(StarSegmentModel request);
    }
}