using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities;
using StravaSegmentSniper.Data.Entities.User;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class UserService : IUserService
    {
        private readonly StravaSegmentSniperDbContext _context;

        public UserService(StravaSegmentSniperDbContext context)
        {
            _context = context;
        }

        public List<ConsoleAppUser> GetAllConsoleAppUsers()
        {

                var query = _context.ConsoleAppUsers;

                return query.ToList();
        }
        public ConsoleAppUser GetConsoleAppUserByStravaId(long stravaAthleteId)
        {
                var query = _context.ConsoleAppUsers
                    .Where(x => x.StravaAthleteId == stravaAthleteId)
                    .First();

                return query;
        }

        public ConsoleAppUser GetConsoleAppUserByUserId(int userId)
        {
                var query = _context.ConsoleAppUsers
                 .Where(x => x.Id == userId)
                 .First();

                return query;
        }
    }
}
