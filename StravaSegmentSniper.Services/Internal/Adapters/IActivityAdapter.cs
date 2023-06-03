using StravaSegmentSniper.Services.Internal.Models.Activity;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public interface IActivityAdapter
    {
        List<ActivityListModel> AdaptDetailedActivitytoActivityList(DetailedActivityModel activity);
        List<ActivityListModel> AdaptSummaryActivityListtoActivityList(List<SummaryActivityModel> activities);
    }
}