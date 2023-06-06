namespace StravaSegmentSniper.React.Controllers.Contracts
{
    public class SegmentSniperContract
    {
        public long ActivityId { get; set; }
        public DateTime ActivityDate { get; set; }
        public int WithinTopTenThreshold { get; set; }
        public double PercentageFromTopTen { get; set; }
    }
}

