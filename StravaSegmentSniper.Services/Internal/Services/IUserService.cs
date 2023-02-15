using StravaSegmentSniper.Data.Entities.User;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IUserService
    {
        List<ConsoleAppUser> GetAllUsers();
        ConsoleAppUser GetUserByStravaId(long stravaAthleteId);
        ConsoleAppUser GetUserByUserId(int userId);
    }
}