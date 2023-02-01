using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Data.Entities.Athlete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class DetailedSegmentEffort
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("DetailedActivity")]
        public long DetailedActivityId { get; set; }

        [ForeignKey("DetailedAthlete")]
        public int AthleteId { get; set; }
        public virtual DetailedAthlete DetailedAthlete { get; set; }
        public virtual DetailedActivity Activity { get; set; }
        public int ElapsedTime { get; set; }
        public int MovingTime { get; set; }
        public DateTime StartDateLocal { get; set; }
        public double Distance { get; set; }
        public double AverageWatts { get; set; }
        public double AverageHeartrate { get; set; }
        public double MaxHeartrate { get; set; }
        public virtual SummarySegment Segment { get; set; }
        public int? PrRank { get; set; }
        public virtual List<Achievement> Achievements { get; set; }
    }
}

//[Key]
//public long Id { get; set; }
//public int ResourceState { get; set; }
//public string Name { get; set; }
//[ForeignKey("Activity")]
//public long ActivityId { get; set; }

//[ForeignKey("User")]
//public int StravaAthleteId { get; set; }
//public virtual Activity.Activity Activity { get; set; }
//// public virtual MetaAthlete Athlete { get; set; }
//public int ElapsedTime { get; set; }
//public int MovingTime { get; set; }
//public DateTime StartDate { get; set; }
//public DateTime StartDateLocal { get; set; }
//public double Distance { get; set; }
//public int StartIndex { get; set; }
//public int EndIndex { get; set; }
//public bool DeviceWatts { get; set; }
//public double AverageWatts { get; set; }
//public double AverageHeartrate { get; set; }
//public double MaxHeartrate { get; set; }
//public virtual SummarySegment Segment { get; set; }
//public int? PrRank { get; set; }
//public virtual List<Achievement> Achievements { get; set; }
//public bool Hidden { get; set; }