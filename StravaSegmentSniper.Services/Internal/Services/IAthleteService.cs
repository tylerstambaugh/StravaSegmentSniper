using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public interface IAthleteService
    {
        DetailedAthleteModel GetDetailedAthlete(int userId);
        int SavedDetailedAtheleteToDb(DetailedAthleteModel model);

        List<DetailedAthlete> GetDetailedAthletes();
    }
}