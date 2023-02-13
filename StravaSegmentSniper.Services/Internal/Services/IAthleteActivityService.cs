using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IAthleteActivityService
    {
        List<DetailedSegmentModel> GetAllDetailedSegments(int userId);
        DetailedActivityModel GetDetailedActivityByActivityId(int userId, long activityId);
        List<SummaryActivityModel> GetSummaryActivityForATimeRange(int userId, int after, int before);
        int SaveDetailedActivityToDB(DetailedActivityModel model, int detailedAthleteId);
    }
}