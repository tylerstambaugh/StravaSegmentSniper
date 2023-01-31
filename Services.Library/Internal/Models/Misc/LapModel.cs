using StravaSegmentSniperServices.Library.Internal.Models.Athlete;
using StravaSegmentSniperServices.Library.Internal.Models.Activity;

namespace StravaSegmentSniperServices.Library.Internal.Models.Misc
{
    public class LapModel
    {
        public long Id { get; set; }
        public int ResourceState { get; set; }
        public string Name { get; set; }
        public ActivityModel Activity { get; set; }
        public MetaAthleteModel Athlete { get; set; }
        public int ElapsedTime { get; set; }
        public int MovingTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime StartDateLocal { get; set; }
        public double Distance { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public double TotalElevationGain { get; set; }
        public double AverageSpeed { get; set; }
        public double MaxSpeed { get; set; }
        public bool DeviceWatts { get; set; }
        public double AverageWatts { get; set; }
        public double AverageHeartrate { get; set; }
        public double MaxHeartrate { get; set; }
        public int LapIndex { get; set; }
        public int Split { get; set; }
    }


}
