﻿using StravaSegmentSniper.React.ActionHandlers.Activity.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.UIModels.Activity;

namespace StravaSegmentSniper.React.ActionHandlers.Activity
{
    public interface IStravaActivityActionHandler
    {
        List<ActivityListModel> HandleGetActivityListById(HandleGetActivityByIdContract contract);
        DetailedActivityUIModel HandleGetActivityDetailById(HandleGetActivityByIdContract contract);

        List<ActivityListModel> HandleGetSummaryActivitiesForDateRange(HandleGetSummaryActivitiesForDateRangeContract contract);
    }
}