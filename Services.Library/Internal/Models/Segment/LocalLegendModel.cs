namespace StravaSegmentSniperServices.Library.Internal.Models.Segment
{
    public class LocalLegendModel
    {
        public long AthleteId { get; set; }
        public string Title { get; set; }
        public string Profile { get; set; }
        public string EffortDescription { get; set; }
        public string EffortCount { get; set; }
        public EffortCountsModel EffortCounts { get; set; }
        public string Destination { get; set; }
    }

}
