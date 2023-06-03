using StravaSegmentSniper.Services.Internal.Models.Activity;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public interface IActivityAdapter
    {
        List<ActivityListModel> AdaptDetailedActivitytoActivityList(DetailedActivityModel activity);
        ActivityListModel AdaptSummaryActivitytoActivityList(SummaryActivityModel activity);
    }
}