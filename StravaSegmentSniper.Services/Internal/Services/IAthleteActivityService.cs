using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IAthleteActivityService
    {
        List<DetailedSegmentModel> GetAllDetailedSegments(long stravaAthleteId);
        DetailedActivityModel GetDetailedActivityByActivityId(long stravaAthleteId, long activityId);
        List<SummaryActivityModel> GetSummaryActivityForATimeRange(long stravaAthleteId, int after, int before);
        string SaveDetailedActivityToDB(DetailedActivityModel model);
    }
}