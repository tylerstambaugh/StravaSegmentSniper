using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.React.Controllers.Athlete
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class Athlete : ControllerBase
    {
        private readonly IAthleteService _athleteService;

        public Athlete(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        public IEnumerable<DetailedAthlete> GetDetailedAthletes()
        {
            return _athleteService.GetDetailedAthletes();
        }

        [HttpGet("{id}")]
        public DetailedAthlete GetDetailedAthleteById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
