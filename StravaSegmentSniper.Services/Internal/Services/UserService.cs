using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class UserService : IUserService
    {
        private readonly StravaSegmentSniperDBContext _context;

        public UserService(StravaSegmentSniperDBContext context)
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
                .Where(x => x.Athlete.StravaAthleteId == stravaAthleteId)
                .First();

            return query;
        }
    }
}
