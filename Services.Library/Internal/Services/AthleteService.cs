using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniperServices.Library.Internal.Services
{
    public class AthleteService : IAthleteService
    {
        private readonly StravaSegmentSniperDBContext _context;


        public AthleteService(StravaSegmentSniperDBContext context)
        {
            _context = context;
        }


        public List<User> GetAllUsers()
        {
            var query = _context.Users;

            return query.ToList();
        }
        public User GetUserByStravaId(long stravaAthleteId)
        {
            var query = _context.Users
                .Where(x => x.StravaAthleteId == stravaAthleteId)
                .First();

            return query;
        }

    }
}
