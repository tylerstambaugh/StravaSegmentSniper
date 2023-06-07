using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.UIModels.Segment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.Internal.Adapters
{
    public class SegmentAdapter : ISegmentAdapter
    {
        public SegmentUIModel AdaptDeailtedSegmentEffortToSegmentUIModel(DetailedSegmentEffortModel model)
        {
            SegmentUIModel returnModel = new SegmentUIModel
            {
                Id = model.Id,
                Name = model.Name,
                Distance = model.Distance,
                Time = model.ElapsedTime,
            };
            return returnModel;
        }
    }
}
