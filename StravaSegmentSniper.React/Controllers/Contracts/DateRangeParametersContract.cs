using Newtonsoft.Json;
using StravaSegmentSniper.Services.Enums;

namespace StravaSegmentSniper.React.Controllers.Contracts
{
    public class DateRangeParametersContract
    {
        public DateTime? EndDate { get; set; }
        public DateTime? StartDate { get; set; }
        public ActivityTypeEnum? ActivityType { get; set; }
    }
}