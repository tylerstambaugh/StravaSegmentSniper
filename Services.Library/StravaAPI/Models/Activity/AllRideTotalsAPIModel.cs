namespace StravaSegmentSniperServices.Library.StravaAPI.Models.Activity
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AllRideTotalsAPIModel
    {
        public int count { get; set; }
        public int distance { get; set; }
        public int moving_time { get; set; }
        public int elapsed_time { get; set; }
        public int elevation_gain { get; set; }
    }


}
