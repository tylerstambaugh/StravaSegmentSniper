using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Athlete;

namespace StravaSegmentSniper.Services.StravaAPI.Models.Segment
{
    public class DetailedSegmentEffortAPIModel
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
        public bool device_watts { get; set; }
        public double average_watts { get; set; }
        public double average_heartrate { get; set; }
        public double max_heartrate { get; set; }
        public SummarySegmentAPIModel segment { get; set; }
        public int? pr_rank { get; set; }
        public List<AchievementAPIModel> achievements { get; set; }
        public bool hidden { get; set; }
    }


}
