using StravaSegmentSniper.React.ActionHandlers.Activity.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;

namespace StravaSegmentSniper.React.ActionHandlers.Activity
{
    public interface IStravaActivityActionHandler
    {
        List<ActivityListModel> HandleGetActivityById(HandleGetActivityByIdContract contract);
        List<ActivityListModel> HandleGetSummaryActivitiesForDateRange(HandleGetSummaryActivitiesForDateRangeContract contract);
    }
}