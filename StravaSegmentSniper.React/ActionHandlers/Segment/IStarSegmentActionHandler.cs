namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public interface IStarSegmentActionHandler
    {
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
