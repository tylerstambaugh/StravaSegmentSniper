namespace StravaSegmentSniper.React.Controllers.Contracts
{
    public class SegmentSniperContract
    {
        public long ActivityId { get; set; }
        public int WithinTopTenThreshold { get; set; }
        public int PercentageFromTopTen { get; set; }
    }
}

