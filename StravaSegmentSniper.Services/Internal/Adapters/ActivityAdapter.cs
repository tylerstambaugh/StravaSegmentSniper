using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public ActivityListModel AdaptSummaryActivitytoActivityList(SummaryActivityModel activity)
        {
            throw new NotImplementedException();
        }
    }
}

