using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IUserService
    {
        List<User> GetAllUsers();
        User GetUserByStravaId(long stravaAthleteId);
    }
}