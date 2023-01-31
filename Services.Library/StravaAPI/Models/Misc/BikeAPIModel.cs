namespace StravaSegmentSniperServices.Library.StravaAPI.Models.Misc
{
    public class BikeAPIModel
    {
        public string id { get; set; }
        public bool primary { get; set; }
        public string name { get; set; }
        public string nickname { get; set; }
        public int resource_state { get; set; }
        public bool retired { get; set; }
        public int distance { get; set; }
        public double converted_distance { get; set; }
    }


}
