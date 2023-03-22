using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class LocalLegend
    {
        [Key]
        public int Id { get; set; }

        public long StravaAthleteId { get; set; }

        [ForeignKey("DetailedSegmentEffort")]
        public long DetailedSegmentEffortId { get; set; }
        public virtual DetailedSegmentEffort DetailedSegmentEffort { get; set; }

        [ForeignKey("EffortCount")]
        public int EffortCountId { get; set; }
        public virtual EffortCount EffortCounts { get; set; }

        public string Title { get; set; }

        public string Profile { get; set; }

        public string EffortDescription { get; set; }

        public string EffortCount { get; set; }


        public string Destination { get; set; }
    }
}
