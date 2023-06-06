using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.UIModels.Segment;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public interface IStravaSegmentActionHandler
    {
        List<SnipedSegmentUIModel> HandleSnipingSegments(SegmentSniperContract contract);
    }
}