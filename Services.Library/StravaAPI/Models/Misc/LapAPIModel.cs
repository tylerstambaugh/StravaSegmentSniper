using StravaSegmentSniper.Library.StravaAPI.Models.Activity;
using StravaSegmentSniperServices.Library.StravaAPI.Models.Athlete;

namespace StravaSegmentSniperServices.Library.StravaAPI.Models.Misc
{
    public class LapAPIModel
    {
        public long id { get; set; }
        public int resource_state { get; set; }
        public string name { get; set; }
        public ActivityAPIModel activity { get; set; }
        public AthleteAPIModel athlete { get; set; }
        public int elapsed_time { get; set; }
        public int moving_time { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_date_local { get; set; }
        public double distance { get; set; }
        public int start_index { get; set; }
        public int end_index { get; set; }
        public double total_elevation_gain { get; set; }
        public double average_speed { get; set; }
        public double max_speed { get; set; }
        public bool device_watts { get; set; }
        public double average_watts { get; set; }
        public double average_heartrate { get; set; }
        public double max_heartrate { get; set; }
        public int lap_index { get; set; }
        public int split { get; set; }
    }


}
