using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.UIModels.Segment;
using System.Diagnostics;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public class SegmentAdapter : ISegmentAdapter
    {
        public SegmentEffortUIListModel AdaptDetailedSegmentEffortToSegmentUIModel(DetailedSegmentEffortModel model)
        {
            SegmentEffortUIListModel returnModel = new SegmentEffortUIListModel
            {
                SegmentId = model.Segment.Id,
                SegmentEffortId = model.SegmentEffortId,
                ActivityId = model.Activity.ActivityId,
                Name = model.Name,
                Distance = Math.Round(CommonConversionHelpers.ConvertMetersToMiles(model.Distance), 2),
                Time = TimeSpan.FromSeconds(model.ElapsedTime).ToString(@"hh\:mm\:ss"),
                Starred = model.Segment.Starred,
                
                //Rank = model.Achievements.OrderBy(r => r.Rank).First().Rank,
            };
            return returnModel;
        }
    }
}
