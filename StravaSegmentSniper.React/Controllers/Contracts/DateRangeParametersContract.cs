using Newtonsoft.Json;

namespace StravaSegmentSniper.React.Controllers.Contracts
{
    public class DateRangeParametersContract
    {
        [JsonProperty]
        public DateTime? EndDate { get; set; }
        [JsonProperty]
        public DateTime? StartDate { get; set; }
    }
}