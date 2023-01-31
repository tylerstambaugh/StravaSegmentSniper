using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniperServices.Library.Internal.Services
{
    public interface IAthleteService
    {
        List<User> GetAllUsers();
        User GetUserByStravaId(long stravaAthleteId);
    }
}