namespace StravaSegmentSniper.Services.StravaAPI.Models.Activity
{

    public class ActivityStatsAPIModel
    {
        public double biggest_ride_distance { get; set; }
        public double biggest_climb_elevation_gain { get; set; }
        public RecentRideTotalsAPIModel recent_ride_totals { get; set; }
        public AllRideTotalsAPIModel all_ride_totals { get; set; }
        public RecentRunTotalsAPIModel recent_run_totals { get; set; }
        public AllRunTotalsAPIModel all_run_totals { get; set; }
        public RecentSwimTotalsAPIModel recent_swim_totals { get; set; }
        public AllSwimTotalsAPIModel all_swim_totals { get; set; }
        public YtdRideTotalsAPIModel ytd_ride_totals { get; set; }
        public YtdRunTotalsAPIModel ytd_run_totals { get; set; }
        public YtdSwimTotalsAPIModel ytd_swim_totals { get; set; }
    }


}
