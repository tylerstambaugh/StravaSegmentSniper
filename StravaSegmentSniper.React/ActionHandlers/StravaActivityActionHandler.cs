﻿using StravaSegmentSniper.React.ActionHandlers.Contracts;
using StravaSegmentSniper.Services.Internal.Adapters;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using System.Security.Claims;

namespace StravaSegmentSniper.React.ActionHandlers
{
    public class StravaActivityActionHandler : IStravaActivityActionHandler
    {
        private readonly IStravaAPIActivity _stravaAPIActivity;
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IActivityAdapter _activityAdapter;

        public StravaActivityActionHandler(IStravaAPIActivity stravaAPIActivity, IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor, IActivityAdapter activityAdapter)
        {
            _stravaAPIActivity = stravaAPIActivity;
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
            _activityAdapter = activityAdapter;
        }

        public ActivityListModel HandleGetActivityById(HandleGetActivityByIdContract contract)
        {
            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var stravaAthleteId = user.StravaAthleteId;
            DetailedActivityModel detailedActivityModel = _stravaAPIActivity.GetDetailedActivityById(contract.activityId, stravaAthleteId).Result;

            ActivityListModel activity = _activityAdapter.AdaptDetailedActivitytoActivityList(detailedActivityModel);

            return activity;
        }
    }
}
