using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.UIModels.Segment;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public interface ISnipeSegmentActionHandler
    {
        List<SnipedSegmentUIModel> HandleSnipingSegments(SegmentSniperContract contract, string userId);
    }
}