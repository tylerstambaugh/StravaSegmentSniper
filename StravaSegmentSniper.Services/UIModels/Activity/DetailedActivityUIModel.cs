using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Misc;
using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.Services.UIModels.Activity
{
    public class DetailedActivityUIModel
    {

        public long Id { get; set; }

        public int DetailedAthleteId { get; set; }
        public string Name { get; set; }
        public double Distance { get; set; }
        public int MovingTime { get; set; }
        public double TotalElevationGain { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal { get; set; }
        public int AchievementCount { get; set; }
        public PolylineMapModel Map { get; set; }
        public double AverageSpeed { get; set; }
        public double MaxSpeed { get; set; }
        public int PrCount { get; set; }
        public string Description { get; set; }
        public List<DetailedSegmentEffortModel> SegmentEfforts { get; set; }
    }
}
