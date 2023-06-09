using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.UIModels.Segment;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public class SegmentAdapter : ISegmentAdapter
    {
        public SegmentEffortUIListModel AdaptDeailtedSegmentEffortToSegmentUIModel(DetailedSegmentEffortModel model)
        {
            SegmentEffortUIListModel returnModel = new SegmentEffortUIListModel
            {
                Id = model.Id,
                ActivityId = model.Activity.Id,
                Name = model.Name,
                Distance = model.Distance,
                Time = model.ElapsedTime,
                //Rank = model.Achievements.OrderBy(r => r.Rank).First().Rank,
            };
            return returnModel;
        }
    }
}
