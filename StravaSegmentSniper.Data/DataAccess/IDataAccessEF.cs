using StravaSegmentSniper.Data.Entities.Activity;

namespace StravaSegmentSniper.Data.DataAccess
{
    public interface IDataAccessEF
    {
        int SaveDetailedActivity(DetailedActivity detailedActivity);
    }
}