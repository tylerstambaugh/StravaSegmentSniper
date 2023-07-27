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
        public StarSegmentModel(long segmentId, bool isStarred, string userId)
        {
            SegmentId = segmentId;
            IsStarred = isStarred;
            UserId = userId;
        }

        public long SegmentId { get; set; }
        public bool IsStarred { get; set; }
        public string UserId { get; set; }
    }
}
