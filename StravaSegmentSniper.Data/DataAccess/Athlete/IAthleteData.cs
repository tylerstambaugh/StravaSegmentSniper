using StravaSegmentSniper.Data.Entities.Athlete;

namespace StravaSegmentSniper.Data.DataAccess.Athlete
{
    public interface IAthleteData
    {
        List<DetailedAthlete> GetDetailedAthletes();
        int SaveDetailedAthlete(DetailedAthlete detailedAthlete);

    }
}