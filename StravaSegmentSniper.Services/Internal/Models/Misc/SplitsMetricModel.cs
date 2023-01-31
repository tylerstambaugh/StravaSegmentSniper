namespace StravaSegmentSniper.Services.Internal.Models.Misc
{
    public class SplitsMetricModel
    {
        public double Distance { get; set; }
        public int ElapsedTime { get; set; }
        public double ElevationDifference { get; set; }
        public int MovingTime { get; set; }
        public int Split { get; set; }
        public double AverageSpeed { get; set; }
        public object AverageGradeAdjustedSpeed { get; set; }
        public double AverageHeartrate { get; set; }
        public int PaceZone { get; set; }
    }
}
