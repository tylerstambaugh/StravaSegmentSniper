using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IAthleteService
    {
        List<User> GetAllUsers();
        User GetUserByStravaId(long stravaAthleteId);
    }
}