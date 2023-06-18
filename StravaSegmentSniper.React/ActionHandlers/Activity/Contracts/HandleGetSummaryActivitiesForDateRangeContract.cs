using StravaSegmentSniper.Services.Enums;
using static StravaSegmentSniper.Services.Enums.ActivityTypeEnum;

namespace StravaSegmentSniper.React.ActionHandlers.Activity.Contracts
{
    public class HandleGetSummaryActivitiesForDateRangeContract
    {

        public HandleGetSummaryActivitiesForDateRangeContract(DateTime startDate, DateTime endDate, ActivityType activityType)
        {
            StartDate = startDate;
            EndDate = endDate;
            ActivityType = activityType;
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityType? ActivityType { get;  }
    }
}