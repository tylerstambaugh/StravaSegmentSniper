using Newtonsoft.Json;
using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public interface IStarSegmentActionHandler
    {
       Task<StarSegmentModel> HandleStarSegment(StarSegmentRequest request, string userId);
    }

    public class StarSegmentRequest
    {
        public StarSegmentRequest(long segmentId, bool starSegment)
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
