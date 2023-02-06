using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class UserService : IUserService
    {
        private readonly IStravaSegmentSniperDBContext _context;

        public UserService(IStravaSegmentSniperDBContext context)
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

        public User GetUserByUserId(int userId)
        {
            var query = _context.Users
                 .Where(x => x.Id == userId)
                 .First();

            return query;
        }
    }
}
