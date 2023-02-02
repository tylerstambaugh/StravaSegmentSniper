using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DetailedSegmentEffortId")]
        public int DetailedSegmentEffortId { get; set; }
        public virtual DetailedSegmentEffort DetailedSegementEffort { get; set; }

        public int TypeId { get; set; }

        public string Type { get; set; }

        public int Rank { get; set; }
    }
}
