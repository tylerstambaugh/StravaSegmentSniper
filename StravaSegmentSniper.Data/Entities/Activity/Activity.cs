using System.ComponentModel.DataAnnotations;

namespace StravaSegmentSniper.Data.Entities.Activity
{
    public class Activity
    {
        [Key]
        public long Id { get; set; }
        public int ResourceState { get; set; }
    }
}
