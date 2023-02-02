using System.ComponentModel.DataAnnotations;

namespace StravaDataAnalyzerDataEF.Entities.Segment
{
    public class SummarySegment
    {
        [Key]
        public int Id { get; set; }

        public long StravaSegmentID { get; set; }

        public string Name { get; set; }

        public string ActivityType { get; set; }

        public double Distance { get; set; }

        public double AverageGrade { get; set; }

        public double MaximumGrade { get; set; }

        public double ElevationHigh { get; set; }

        public double ElevationLow { get; set; } 

        public int ClimbCategory { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public bool Private { get; set; }

        public bool Hazardous { get; set; }

        public bool Starred { get; set; }

        public string ElevationProfile { get; set; }
    }
}


//[Key]
//public int Id { get; set; }
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
//public int ClimbCategory { get; set; }
//public string City { get; set; }
//public string State { get; set; }
//public string Country { get; set; }
//public bool Private { get; set; }
//public bool Hazardous { get; set; }
//public bool Starred { get; set; }
//public string ElevationProfile { get; set; }
//public List<double> StartLatlng { get; set; }
//public List<double> EndLatlng { get; set; }    