using StravaSegmentSniper.Services.Internal.Models.Activity;

namespace StravaSegmentSniper.Services.StravaAPI.Activity
{
    public interface IStravaAPIActivity
    {
        Task<DetailedActivityModel> GetDetailedActivityById(long activityId, string userId);
        Task<List<SummaryActivityModel>> GetSummaryActivityForTimeRange(int after, int before, string userId);
    }
}