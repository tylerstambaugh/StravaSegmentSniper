using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.UIModels.Activity;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public interface IActivityAdapter
    {
        List<ActivityListModel> AdaptDetailedActivitytoActivityList(DetailedActivityModel activity);
        List<ActivityListModel> AdaptSummaryActivityListtoActivityList(List<SummaryActivityModel> activities);
        DetailedActivityUIModel AdaptDetailedActivityModelToDetailedActivityUIModel(DetailedActivityModel detailedActivityModel);
    }
}