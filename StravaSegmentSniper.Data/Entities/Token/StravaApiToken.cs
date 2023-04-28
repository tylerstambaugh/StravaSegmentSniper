using StravaSegmentSniper.Data.Entities.Athlete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaSegmentSniper.Data.Entities.Token
{
    public class StravaApiToken
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }

        [ForeignKey("DetailedAthlete")]
        public int? DetailedAthleteId { get; set; }
        public virtual DetailedAthlete Athlete { get; set; }

        public string? AuthorizationToken { get; set; }

        public string? RefreshToken { get; set; }

        public long ExpiresAt { get; set; }

        public long ExpiresIn { get; set; }
    }
}
