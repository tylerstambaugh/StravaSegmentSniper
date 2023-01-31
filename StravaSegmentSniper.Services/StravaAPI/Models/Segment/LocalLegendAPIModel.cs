namespace StravaSegmentSniper.Services.StravaAPI.Models.Segment
{
    public class LocalLegendAPIModel
    {
        public int athlete_id { get; set; }
        public string title { get; set; }
        public string profile { get; set; }
        public string effort_description { get; set; }
        public string effort_count { get; set; }
        public EffortCountsAPIModel effort_counts { get; set; }
        public string destination { get; set; }
    }


}
