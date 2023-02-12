using StravaSegmentSniper.Data.Entities;
using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Data.DataAccess
{
    public class DataAccessEF : IDataAccessEF
    {
        private readonly StravaSegmentSniperDBContext _context;
        public DataAccessEF(StravaSegmentSniperDBContext context)
        {
            _context = context;
        }

        public int SaveDetailedActivity(DetailedActivity detailedActivity)
        {
            var existingActivityCount = _context.DetailedActivities.Where(x => x.Id == detailedActivity.Id).Count();
            if (existingActivityCount > 0)
            {
                return -2;
            }
            else
            {
                _context.DetailedActivities.Add(detailedActivity);

                if (_context.SaveChanges() == 1)
                    return 1;
                return -1;
            }
        }

        public int SaveDetailedAthlete(DetailedAthlete detailedAthlete)
        {
            var existingActivityCount = _context.DetailedAthletes.Where(x => x.Id == detailedAthlete.Id).Count();
            if (existingActivityCount > 0)
            {
                return -2;
            }
            else
            {
                _context.DetailedAthletes.Add(detailedAthlete);

                if (_context.SaveChanges() == 1)
                    return 1;
                return -1;
            }
        }
    }
}
