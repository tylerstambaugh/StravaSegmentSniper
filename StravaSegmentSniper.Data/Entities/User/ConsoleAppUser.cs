using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Data.Entities.User
{
    public class ConsoleAppUser
    {
        [Key]
        public int Id { get; set; }

        public long StravaAthleteId { get; set; }

        [ForeignKey("DetailedAthlete")]
        public int? DetailedAthleteId { get; set; }
        public virtual DetailedAthlete Athlete { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

    }
}
