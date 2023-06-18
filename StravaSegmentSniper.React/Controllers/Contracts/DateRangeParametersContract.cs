using Newtonsoft.Json;
using StravaSegmentSniper.Services.Enums;
using static StravaSegmentSniper.Services.Enums.ActivityTypeEnum;

namespace StravaSegmentSniper.React.Controllers.Contracts
{
    public class DateRangeParametersContract
    {
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string? ActivityType { get; set; }
    }
}