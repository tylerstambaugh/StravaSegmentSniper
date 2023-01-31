namespace StravaSegmentSniper.Services.StravaAPI.Models.Misc
{ 
    public class ClubAPIModel
    {
        public int id { get; set; }
        public int resource_state { get; set; }
        public string name { get; set; }
        public string profile_medium { get; set; }
        public string profile { get; set; }
        public string cover_photo { get; set; }
        public string cover_photo_small { get; set; }
        public List<string> activity_types { get; set; }
        public string activity_types_icon { get; set; }
        public List<string> dimensions { get; set; }
        public string sport_type { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public bool @private { get; set; }
        public int member_count { get; set; }
        public bool featured { get; set; }
        public bool verified { get; set; }
        public string url { get; set; }
        public string membership { get; set; }
        public bool admin { get; set; }
        public bool owner { get; set; }
    }


}
