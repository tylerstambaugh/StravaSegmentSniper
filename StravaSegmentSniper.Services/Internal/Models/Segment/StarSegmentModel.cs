using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.Internal.Models.Segment
{
    public class StarSegmentModel
    {
        public StarSegmentModel()
        {
        }
        public StarSegmentModel(string segmentId, bool isStarred, string userId)
        {
            SegmentId = segmentId;
            IsStarred = isStarred;
            UserId = userId;
        }

        public string SegmentId { get; set; }
        public bool IsStarred { get; set; }
        public string UserId { get; set; }
    }
}
