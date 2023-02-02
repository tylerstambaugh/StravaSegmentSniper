using StravaSegmentSniper.Data.Entities.Misc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaSegmentSniper.Data.Entities.Athlete
{
    public  class DetailedAthlete
    {
        [Key]
        public int Id { get; set; }

        public long StravaAthleteId { get; set; }

        public string Username { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Bio { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Sex { get; set; }

        public DateTime? CreatedAt { get; set; }

        public double? Weight { get; set; }

        public string? ProfileMedium { get; set; }

        public string? Profile { get; set; }

        public int? FollowerCount { get; set; }

        public int? FriendCount { get; set; }

        public int? MutualFriendCount { get; set; }

        public int? AthleteType { get; set; }

        public string? DatePreference { get; set; }

        public string? MeasurementPreference { get; set; }

        public List<Bike>? Bikes { get; set; }
    }
}

//[Key]
//public int Id { get; set; }
//public string Username { get; set; }
//public int ResourceState { get; set; }
//public string Firstname { get; set; }
//public string Lastname { get; set; }
//public string Bio { get; set; }
//public string City { get; set; }
//public string State { get; set; }
//public string Country { get; set; }
//public string Sex { get; set; }
//public bool Premium { get; set; }
//public bool Summit { get; set; }
//public DateTime CreatedAt { get; set; }
//public DateTime UpdatedAt { get; set; }
//public int BadgeTypeId { get; set; }
//public double Weight { get; set; }
//public string ProfileMedium { get; set; }
//public string Profile { get; set; }
//public bool Blocked { get; set; }
//public bool CanFollow { get; set; }
//public int FollowerCount { get; set; }
//public int FriendCount { get; set; }
//public int MutualFriendCount { get; set; }
//public int AthleteType { get; set; }
//public string DatePreference { get; set; }
//public string MeasurementPreference { get; set; }
//public List<Bike> Bikes { get; set; }
//public bool IsWinbackViaUpload { get; set; }
//public bool IsWinbackViaView { get; set; }

//// public object Friend { get; set; }
////public object Follower { get; set; }
//// public List<ClubModel> Clubs { get; set; }
//// public object Ftp { get; set; }
//// public List<object> Shoes { get; set; }
