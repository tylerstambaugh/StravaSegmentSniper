using StravaSegmentSniper.Services.Enums;

namespace StravaSegmentSniper.React.ActionHandlers.Activity.Contracts
{
    public class HandleGetSummaryActivitiesForDateRangeContract
    {

        public HandleGetSummaryActivitiesForDateRangeContract(DateTime startDate, DateTime endDate, ActivityTypeEnum activityType)
        {
            StartDate = startDate;
            EndDate = endDate;
            ActivityType = activityType;
        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ActivityTypeEnum? ActivityType { get;  }
    }
}