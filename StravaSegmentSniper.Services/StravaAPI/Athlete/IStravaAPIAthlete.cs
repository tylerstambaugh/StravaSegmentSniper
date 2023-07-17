using StravaSegmentSniper.Services.Internal.Models.Athlete;

namespace StravaSegmentSniper.Services.StravaAPI.Athlete
{
    public interface IStravaAPIAthlete
    {
        Task<DetailedAthleteModel> GetDetailedAthleteFromStrava(string userId);
    }
}