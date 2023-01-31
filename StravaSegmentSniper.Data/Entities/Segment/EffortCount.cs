using System.ComponentModel.DataAnnotations;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class EffortCount
    {
        [Key]
        public int Id { get; set; }
        public string Overall { get; set; }
        public string Female { get; set; }
    }
}
