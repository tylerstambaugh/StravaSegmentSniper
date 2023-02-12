using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Data.DataAccess
{
    public interface IDataAccessEF
    {
        int SaveDetailedActivity(DetailedActivity detailedActivity);
        int SaveDetailedAthlete(DetailedAthlete detailedAthlete);
    }
}