using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.Services.StravaAPI.Segment
{
    public interface IStravaAPISegment
    {
        Task<DetailedSegmentModel> GetDetailedSegmentById(long segmentId, int userId);
        Task<DetailedSegmentEffortModel> GetSegmentEffortById(int userId, int segmentEffortId);
        Task<List<DetailedSegmentEffortModel>> GetSegmentEffortsBySegmentId(int segmentId, DateTime startDate, DateTime endDate, int userId);
    }
}