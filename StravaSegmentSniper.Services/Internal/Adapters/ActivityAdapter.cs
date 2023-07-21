using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.UIModels.Activity;
using StravaSegmentSniper.Services.UIModels.Segment;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public class ActivityAdapter : IActivityAdapter
    {
        private readonly ISegmentAdapter _segmentAdapter;

        public ActivityAdapter(ISegmentAdapter segmentAdapter)
        {
            _segmentAdapter = segmentAdapter;
        }
        public ActivityListModel AdaptDetailedActivitytoActivityList(DetailedActivityModel activity)
        {
            List<SegmentEffortUIListModel> segments = new List<SegmentEffortUIListModel>();

            foreach (DetailedSegmentEffortModel segmentEffort in activity.SegmentEfforts)
            {
                segments.Add(_segmentAdapter.AdaptDetailedSegmentEffortToSegmentUIModel(segmentEffort));
            }

            ActivityListModel returnActivity = new ActivityListModel
            {
                Id = activity.Id,
                Name = activity.Name,
                Distance = Math.Round(CommonConversionHelpers.ConvertMetersToMiles(activity.Distance), 2),
                Type = activity.Type,
                StartDate = activity.StartDate.ToShortDateString(),
                ElapsedTimeSeconds = activity.ElapsedTime,
                ElapsedTime = TimeSpan.FromSeconds(activity.ElapsedTime).ToString(@"hh\:mm\:ss"),
                AchievementCount = activity.AchievementCount,
                MaxSpeed = Math.Round(CommonConversionHelpers.ConvertMetersPerSecondToMilesPerHour(activity.MaxSpeed), 2),
                Segments = segments,
                // StravaMap = activity.Map
            };
            return returnActivity;
        }

 



        //public List<ActivityListModel> AdaptSummaryActivityListtoActivityList(List<SummaryActivityModel> activities)
        //{
        //    List<ActivityListModel> returnList = new List<ActivityListModel>();

        //    foreach (SummaryActivityModel activity in activities)
        //    {
        //        returnList.Add(
        //             new ActivityListModel
        //             {
        //                 Id = activity.Id,
        //                 Name = activity.Name,
        //                 Distance = activity.Distance,
        //                 Type = activity.Type,
        //                 StartDate = activity.StartDate,
        //                 ElapsedTime = activity.ElapsedTime,
        //                 MaxSpeed = activity.MaxSpeed,
        //                 // StravaMap = activity.Map
        //             });
        //    }

        //    return returnList;
        //}

        public DetailedActivityUIModel AdaptDetailedActivityModelToDetailedActivityUIModel(DetailedActivityModel model)
        {

            List<SegmentEffortUIListModel> segments = new List<SegmentEffortUIListModel>();

            foreach (DetailedSegmentEffortModel segmentEffort in model.SegmentEfforts)
            {
                segments.Add(_segmentAdapter.AdaptDetailedSegmentEffortToSegmentUIModel(segmentEffort));
            }
            DetailedActivityUIModel returnModel = new DetailedActivityUIModel
            {

                Id = model.Id,
                DetailedAthleteId = model.DetailedAthleteId,
                Name = model.Name,
                Distance = CommonConversionHelpers.ConvertMetersToMiles(model.Distance),
                MovingTime = model.MovingTime,
                TotalElevationGain = model.TotalElevationGain,
                Type = model.Type,
                StartDate = model.StartDate.ToShortDateString(),
                AchievementCount = model.AchievementCount,
                Map = model.Map,
                AverageSpeed = CommonConversionHelpers.ConvertMetersPerSecondToMilesPerHour(model.AverageSpeed),
                MaxSpeed = Math.Round(CommonConversionHelpers.ConvertMetersPerSecondToMilesPerHour(model.MaxSpeed), 2),
                PrCount = model.PrCount,
                Description = model.Description,
                SegmentEfforts = model.SegmentEfforts
            };

            return returnModel;
        }
    }
}

