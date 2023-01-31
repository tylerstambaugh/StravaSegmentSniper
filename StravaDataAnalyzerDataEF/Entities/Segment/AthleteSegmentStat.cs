using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class AthleteSegmentStat
    {
        [Key]
        public int Id { get; set; }
        public int? PrElapsedTime { get; set; }
        public string? PrDate { get; set; }
        [ForeignKey("DetailedActivity")]
        public long? PrActivityId { get; set; }
        public int? EffortCount { get; set; }
    }
}
