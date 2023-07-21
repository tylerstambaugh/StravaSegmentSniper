using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.UIModels.Segment;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public interface ISegmentAdapter
    {
        SegmentEffortUIListModel AdaptDetailedSegmentEffortToSegmentUIModel(DetailedSegmentEffortModel model);
    }
}