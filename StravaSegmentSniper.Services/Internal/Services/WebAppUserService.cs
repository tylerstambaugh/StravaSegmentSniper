using Authorization.Data.Data;
using Authorization.Data.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class WebAppUserService : IWebAppUserService
    {
        private readonly AuthDbContext _authDbContext;

        public WebAppUserService(AuthDbContext authDbContext)
        {
            _authDbContext = authDbContext;
        }

        public WebAppUser GetLoggedInUserById(string userId)
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

        //remove
        //public WebAppUser GetLoggedInUserByStravaId(long stravaId)
        //{
        //    var userToReturn = _authDbContext.Users.Where(x => x.StravaAthleteId == stravaId).First();

        //    if (userToReturn != null)
        //    {
        //        return userToReturn;
        //    }
        //    else
        //    {
        //        throw new ArgumentException();
        //    }
        //}

        public bool AddStravaIdToWebAppUser(string userId, long stravaId)
        {
            var userToUpdate = GetLoggedInUserById(userId);

            if (userToUpdate != null)
            {   
                userToUpdate.StravaAthleteId = stravaId;
            }

            return _authDbContext.SaveChanges() == 1;
        }
    }
}
