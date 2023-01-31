using StravaSegmentSniperServices.Library.Internal.Models.Activity;
using StravaSegmentSniperServices.Library.Internal.Models.Segment;

namespace StravaSegmentSniperServices.Library.Internal.Services
{
    public interface IAthleteActivityService
    {
        List<DetailedSegmentModel> GetAllDetailedSegments(long stravaAthleteId);
        DetailedActivityModel GetDetailedActivityByActivityId(long stravaAthleteId, long activityId);
        List<SummaryActivityModel> GetSummaryActivityForATimeRange(long stravaAthleteId, int after, int before);
        string SaveDetailedActivityToDB(DetailedActivityModel model);
    }
}