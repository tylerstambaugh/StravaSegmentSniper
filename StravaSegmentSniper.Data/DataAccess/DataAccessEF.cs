using StravaSegmentSniper.Data.Entities.Activity;

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
    }
}
