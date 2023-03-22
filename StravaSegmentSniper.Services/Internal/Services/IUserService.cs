using StravaSegmentSniper.Data.Entities.User;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IUserService
    {
        List<ConsoleAppUser> GetAllConsoleAppUsers();
        ConsoleAppUser GetConsoleAppUserByStravaId(long stravaAthleteId);
        ConsoleAppUser GetConsoleAppUserByUserId(int userId);
    }
}