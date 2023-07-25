using Newtonsoft.Json;
using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public interface IStarSegmentActionHandler
    {
       Task<StarSegmentModel> HandleStarSegment(StarSegmentContract contract);
    }

    public class StarSegmentContract
    {
        public StarSegmentContract(long segmentId, bool starSegment)
        {
            SegmentId = segmentId;
            StarSegment = starSegment;
        }

        [JsonProperty("segmentId")]
        public long SegmentId { get; }
        [JsonProperty("starSegment")]
        public bool StarSegment { get; }
    }
}
