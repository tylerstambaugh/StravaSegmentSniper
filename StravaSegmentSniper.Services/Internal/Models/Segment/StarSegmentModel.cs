using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaSegmentSniper.Services.Internal.Models.Segment
{
    public class StarSegmentModel
    {

        public StarSegmentModel(long segmentId, bool isStarred)
        {
            SegmentId = segmentId;
            IsStarred = isStarred;
        }

        public long SegmentId { get; set; }
        public bool IsStarred { get; set; }
    }
}
