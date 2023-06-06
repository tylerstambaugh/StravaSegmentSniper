using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Misc;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.UIModels.Activity;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public class ActivityAdapter : IActivityAdapter
    {
        public ActivityAdapter()
        {

        }
        public List<ActivityListModel> AdaptDetailedActivitytoActivityList(DetailedActivityModel activity)
        {
            List<ActivityListModel> returnList = new List<ActivityListModel>();

            returnList.Add(
             new ActivityListModel
             {
                 Id = activity.Id,
                 Name = activity.Name,
                 Distance = activity.Distance,
                 Type = activity.Type,
                 StartDate = activity.StartDate,
                 ElapsedTime = activity.ElapsedTime,
                 MaxSpeed = activity.MaxSpeed,
                 // StravaMap = activity.Map
             });
            return returnList;
        }

        public List<ActivityListModel> AdaptSummaryActivityListtoActivityList(List<SummaryActivityModel> activities)
        {
            List<ActivityListModel> returnList = new List<ActivityListModel>();

            foreach (SummaryActivityModel activity in activities)
            {
                returnList.Add(
                     new ActivityListModel
                     {
                         Id = activity.Id,
                         Name = activity.Name,
                         Distance = activity.Distance,
                         Type = activity.Type,
                         StartDate = activity.StartDate,
                         ElapsedTime = activity.ElapsedTime,
                         MaxSpeed = activity.MaxSpeed,
                         // StravaMap = activity.Map
                     });
            }

            return returnList;
        }

        public DetailedActivityUIModel AdaptDetailedActivityModelToDetailedActivityUIModel(DetailedActivityModel model)
        {
            DetailedActivityUIModel returnModel = new DetailedActivityUIModel
            {

                Id = model.Id,
                DetailedAthleteId = model.DetailedAthleteId,
                Name = model.Name,
                Distance = model.Distance,
                MovingTime = model.MovingTime,
                TotalElevationGain = model.TotalElevationGain,
                Type = model.Type,
                StartDate = model.StartDate,
                AchievementCount = model.AchievementCount,
                Map = model.Map,
                AverageSpeed = model.AverageSpeed,
                MaxSpeed = model.MaxSpeed,
                PrCount = model.PrCount,
                Description = model.Description,
                            SegmentEfforts = model.SegmentEfforts
                };

            return returnModel;
        }
    }
}

