using Authorization.Data.Data;
using Authorization.Data.Models;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class WebAppUserService : IWebAppUserService
    {
        private readonly AuthDbContext _authDbContext;

        public WebAppUserService(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public WebAppUser GetLoggedInUser(string userId)
        {
            var userToReturn = _authDbContext.Users.Where(x => x.Id == userId).First();

            if (userToReturn != null)
            {
                return userToReturn;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
