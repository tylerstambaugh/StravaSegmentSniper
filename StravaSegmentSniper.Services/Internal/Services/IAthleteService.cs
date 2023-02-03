using StravaSegmentSniper.Services.Internal.Models.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IAthleteService
    {
        DetailedAthleteModel GetDetailedAthlete(long stravaAthleteId);
    }
}