using StravaSegmentSniper.Data.Entities;
using StravaSegmentSniper.Data.Entities.User;
using StravaSegmentSniperReact.Data;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class UserService : IUserService
    {
        private readonly StravaSegmentSniperDbContext _context;

        public UserService(StravaSegmentSniperDbContext context)
        {
            _context = context;
        }

        public List<ConsoleAppUser> GetAllUsers()
        {
            var query = _context.Users;

            return query.ToList();
        }
        public ConsoleAppUser GetUserByStravaId(long stravaAthleteId)
        {
            var query = _context.Users
                .Where(x => x.StravaAthleteId == stravaAthleteId)
                .First();

            return query;
        }

        public ConsoleAppUser GetUserByUserId(int userId)
        {
            var query = _context.Users
                 .Where(x => x.Id == userId)
                 .First();

            return query;
        }
    }
}
