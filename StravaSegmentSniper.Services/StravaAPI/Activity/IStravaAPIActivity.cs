using StravaSegmentSniper.Services.Internal.Models.Activity;

namespace StravaSegmentSniper.Services.StravaAPI.Activity
{
    public interface IStravaAPIActivity
    {
        Task<DetailedActivityModel> GetDetailedActivityById(long activityId, int userId);
        Task<List<SummaryActivityModel>> GetSummaryActivityForTimeRange(int after, int before, int userId);
    }
}