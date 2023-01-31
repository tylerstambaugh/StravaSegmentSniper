using StravaSegmentSniperServices.Library.StravaAPI.Models.Misc;

namespace StravaSegmentSniperServices.Library.StravaAPI.Models.Athlete
{
    public class DetailedAthleteAPIModel
    {
        public long id { get; set; }
        public string username { get; set; }
        public int resource_state { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string bio { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string sex { get; set; }
        public bool premium { get; set; }
        public bool summit { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int badge_type_id { get; set; }
        public double weight { get; set; }
        public string profile_medium { get; set; }
        public string profile { get; set; }
        public object friend { get; set; }
        public object follower { get; set; }
        public bool blocked { get; set; }
        public bool can_follow { get; set; }
        public int follower_count { get; set; }
        public int friend_count { get; set; }
        public int mutual_friend_count { get; set; }
        public int athlete_type { get; set; }
        public string date_preference { get; set; }
        public string measurement_preference { get; set; }
        public List<ClubAPIModel> clubs { get; set; }
        public object ftp { get; set; }
        public List<BikeAPIModel> bikes { get; set; }
        public List<object> shoes { get; set; }
        public bool is_winback_via_upload { get; set; }
        public bool is_winback_via_view { get; set; }
    }


}
