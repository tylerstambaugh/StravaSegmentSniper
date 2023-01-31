using StravaSegmentSniper.Services.StravaAPI.Models.Misc;

namespace StravaSegmentSniper.Services.StravaAPI.Models.Segment
{
    public class XomsAPIModel
    {
        public string kom { get; set; }
        public string qom { get; set; }
        public string overall { get; set; }
        public DestinationAPIModel destination { get; set; }
    }


}
