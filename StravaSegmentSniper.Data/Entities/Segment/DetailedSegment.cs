using System.ComponentModel.DataAnnotations;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class DetailedSegment
    {
        [Key]
        public int Id { get; set; }

        public long StravaSegmentId { get; set; }

        public string Name { get; set; }

        public double Distance { get; set; }

        public double AverageGrade { get; set; }

        public double MaximumGrade { get; set; }

        public double ElevationHigh { get; set; }

        public double ElevationLow { get; set; }

        public string City { get; set; }

        public bool Starred { get; set; }

        public DateTime UpdatedAt { get; set; }

        public double TotalElevationGain { get; set; }

        public int EffortCount { get; set; }

        public int AthleteCount { get; set; }

        public int StarCount { get; set; }

        public virtual List<AthleteSegmentStat> AthleteSegmentStats { get; set; }

        public virtual List<Xom> Xoms { get; set; }

        public virtual LocalLegend LocalLegend { get; set; }
    }
}

//[Key]
//public long Id { get; set; }
//public int ResourceState { get; set; }
//public string Name { get; set; }
//public string ActivityType { get; set; }
//public double Distance { get; set; }
//public double AverageGrade { get; set; }
//public double MaximumGrade { get; set; }
//public double ElevationHigh { get; set; }
//public double ElevationLow { get; set; }
////public List<double> StartLatlng { get; set; }
////public List<double> EndLatlng { get; set; }
//public string ElevationProfile { get; set; }
//public int ClimbCategory { get; set; }
//public string City { get; set; }
//public string State { get; set; }
//public string Country { get; set; }
//public bool Private { get; set; }
//public bool Hazardous { get; set; }
//public bool Starred { get; set; }
//public DateTime CreatedAt { get; set; }
//public DateTime UpdatedAt { get; set; }
//public double TotalElevationGain { get; set; }
//public virtual Map Map { get; set; }
//public int EffortCount { get; set; }
//public int AthleteCount { get; set; }
//public int StarCount { get; set; }
//public virtual AthleteSegmentStat AthleteSegmentStats { get; set; }
//public virtual Xom Xoms { get; set; }
//public virtual LocalLegend LocalLegend { get; set; }
