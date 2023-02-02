using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaSegmentSniper.Data.Entities.Athlete
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("DetailedAthlete")]
        public int DetailedAthleteId { get; set; }
        public virtual DetailedAthlete Athlete { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailAddress { get; set; }

    }
}
