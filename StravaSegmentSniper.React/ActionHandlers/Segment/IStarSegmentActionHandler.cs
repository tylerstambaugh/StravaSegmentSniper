using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public interface IStarSegmentActionHandler
    {
       Task<StarSegmentModel> HandleStarSegment(StarSegmentActionHandlerContract contract);
    }

    public class StarSegmentActionHandlerContract
    {
        public StarSegmentActionHandlerContract(long segmentId, bool starSegment)
        {
            SegmentId = segmentId;
            StarSegment = starSegment;
        }

        public long SegmentId { get; }
        public bool StarSegment { get; }
    }
}
