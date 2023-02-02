using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class Xom
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DetailedSegmentEffort")]
        public long DetailedSegmentEffortId { get; set; }
        public virtual DetailedSegmentEffort DetailedSegmentEffort { get; set; }

        public string Kom { get; set; }

        public string Qom { get; set; }

        public string Overall { get; set; }
    }
}
