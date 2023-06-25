using StravaSegmentSniper.React.ActionHandlers.Activity.Contracts;
using StravaSegmentSniper.Services.Enums;
using StravaSegmentSniper.Services.Internal.Adapters;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.UIModels.Activity;
using System.Security.Claims;

namespace StravaSegmentSniper.React.ActionHandlers.Activity
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

        public List<ActivityListModel> HandleGetActivityListById(HandleGetActivityByIdContract contract)
        {
            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var stravaAthleteId = user.StravaAthleteId;
            DetailedActivityModel detailedActivityModel = _stravaAPIActivity.GetDetailedActivityById(contract.activityId, stravaAthleteId).Result;

            List<ActivityListModel> activityList = new List<ActivityListModel>();
                activityList.Add(_activityAdapter.AdaptDetailedActivitytoActivityList(detailedActivityModel));
            return activityList;
        }


        //make async
        public List<ActivityListModel> HandleGetActivitListForDateRange(HandleGetSummaryActivitiesForDateRangeContract contract)
        {

            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var stravaAthleteId = user.StravaAthleteId;

            var endDate = contract.EndDate.AddDays(1);

            var unixStartDate = ConvertToEpochTime(contract.StartDate);
            var unixEndDate = ConvertToEpochTime(endDate);


            List<SummaryActivityModel> listOfSummaryActivities = _stravaAPIActivity
                .GetSummaryActivityForTimeRange(unixStartDate, unixEndDate, stravaAthleteId)
                .Result;

            if (contract.ActivityType != ActivityTypeEnum.ActivityType.All)
            {
                listOfSummaryActivities = listOfSummaryActivities
                .Where(sa => sa.Type == contract.ActivityType.ToString()).ToList();
            }

            List<DetailedActivityModel> listOfDetailedActivities = new List<DetailedActivityModel>();

            foreach(SummaryActivityModel activityModel in listOfSummaryActivities)
            {
                listOfDetailedActivities.Add(_stravaAPIActivity.GetDetailedActivityById(activityModel.Id, stravaAthleteId).Result);
            }

            List<ActivityListModel> activitieList = new List<ActivityListModel>();

            foreach (var activity in listOfDetailedActivities)
            {
                activitieList.Add(_activityAdapter.AdaptDetailedActivitytoActivityList(activity));
            }

            return activitieList;
        }

        public DetailedActivityUIModel HandleGetActivityDetailById(HandleGetActivityByIdContract contract)
        {
            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var stravaAthleteId = user.StravaAthleteId;
            DetailedActivityModel detailedActivityModel = _stravaAPIActivity.GetDetailedActivityById(contract.activityId, stravaAthleteId).Result;

            var model = _activityAdapter.AdaptDetailedActivityModelToDetailedActivityUIModel(detailedActivityModel);

            return model;
        }

        private int ConvertToEpochTime(DateTime date)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (int)(date - unixEpoch).TotalSeconds;
        }
    }
}
