using Newtonsoft.Json;

namespace StravaSegmentSniper.React.Controllers.Contracts
{
    public class SegmentSniperContract
    {
        public string ActivityId { get; set; }
        [JsonProperty("secondsOff")]
        public int? SecondsFromKom { get; set; }
        [JsonProperty("percentageOff")]
        public int? PercentageFromKom { get; set; }

        public bool UseQom { get; set; }
    }
}

