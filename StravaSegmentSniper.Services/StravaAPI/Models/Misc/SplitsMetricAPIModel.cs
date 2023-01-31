namespace StravaSegmentSniper.Services.StravaAPI.Models.Misc
{ 
    public class SplitsMetricAPIModel
    {
        public double distance { get; set; }
        public int elapsed_time { get; set; }
        public double elevation_difference { get; set; }
        public int moving_time { get; set; }
        public int split { get; set; }
        public double average_speed { get; set; }
        public object average_grade_adjusted_speed { get; set; }
        public double average_heartrate { get; set; }
        public int pace_zone { get; set; }
    }


}
