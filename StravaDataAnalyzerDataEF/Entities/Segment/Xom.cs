using System.ComponentModel.DataAnnotations;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class Xom
    {
        [Key]
        public int Id { get; set; }
        public string Kom { get; set; }
        public string Qom { get; set; }
        public string Overall { get; set; }
    }
}
