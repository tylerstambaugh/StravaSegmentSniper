namespace StravaSegmentSniperServices.Library.Internal.Models.Activity
{
    public class ActivityStatsModel
    {
        public double BiggestRideDistance { get; set; }
        public double BiggestClimbElevationGain { get; set; }
        public RecentRideTotalsModel RecentRideTotals { get; set; }
        public AllRideTotalsModel AllRideTotals { get; set; }
        public RecentRunTotalsModel RecentRunTotals { get; set; }
        public AllRunTotalsModel AllRunTotals { get; set; }
        public RecentSwimTotalsModel RecentSwimTotals { get; set; }
        public AllSwimTotalsModel AllSwimTotals { get; set; }
        public YtdRideTotalsModel YtdRideTotals { get; set; }
        public YtdRunTotalsModel YtdRunTotals { get; set; }
        public YtdSwimTotalsModel YtdSwimTotals { get; set; }
    }


}
