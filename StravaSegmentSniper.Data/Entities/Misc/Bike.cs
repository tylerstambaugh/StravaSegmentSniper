using StravaSegmentSniper.Data.Entities.Athlete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StravaSegmentSniper.Data.Entities.Misc
{
    public class Bike
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey("DetailedAthlete")]
        public int DetailedAthleteId { get; set; }
        public virtual DetailedAthlete DetailedAthlete { get; set; }

        public bool Primary { get; set; }

        public string Name { get; set; }

        public string Nickname { get; set; }

        public bool Retired { get; set; }

        public int Distance { get; set; }

        public double ConvertedDistance { get; set; }
    }
}
