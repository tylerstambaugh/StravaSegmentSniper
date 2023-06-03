using StravaSegmentSniper.React.ActionHandlers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;

namespace StravaSegmentSniper.React.ActionHandlers
{
    public interface IStravaActivityActionHandler
    {
        List<ActivityListModel> HandleGetActivityById(HandleGetActivityByIdContract contract);
        List<ActivityListModel> HandleGetSummaryActivitiesForDateRange(HandleGetSummaryActivitiesForDateRangeContract contract);
    }
}