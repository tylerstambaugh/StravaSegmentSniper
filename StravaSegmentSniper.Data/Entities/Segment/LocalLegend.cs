using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class LocalLegend
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("DetailedAthlete")]
        public long AthleteId { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
        public string EffortDescription { get; set; }
        public string EffortCount { get; set; }
        public EffortCount EffortCounts { get; set; }
        public string Destination { get; set; }
    }
}
