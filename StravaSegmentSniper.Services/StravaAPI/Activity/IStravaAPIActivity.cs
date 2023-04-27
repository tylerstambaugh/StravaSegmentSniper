using StravaSegmentSniper.Services.Internal.Models.Activity;

namespace StravaSegmentSniper.Services.StravaAPI.Activity
{
    public interface IStravaAPIActivity
    {
        Task<DetailedActivityModel> GetDetailedActivityById(long activityId, long stravaAthleteId);
        Task<List<SummaryActivityModel>> GetSummaryActivityForTimeRange(int after, int before, long stravaAthleteId);
    }
}