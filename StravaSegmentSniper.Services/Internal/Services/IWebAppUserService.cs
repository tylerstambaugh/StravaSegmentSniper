using Authorization.Data.Models;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IWebAppUserService
    {
        WebAppUser GetLoggedInUser(string userId);
    }
}