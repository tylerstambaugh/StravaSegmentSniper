using Authorization.Data.Models;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IWebAppUserService
    {
        WebAppUser GetLoggedInUserById(string userId);
        WebAppUser GetLoggedInUserByStravaId(long stravaId);
    }
}