using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AthleteController : ControllerBase
    {
        private readonly IAthleteService _athleteService;

        public AthleteController(IAthleteService athleteService)
        {
            _athleteService = athleteService;
        }
        public IEnumerable<DetailedAthlete> GetDetailedAthletes()
        {
            return _athleteService.GetDetailedAthletes();
        }

        [HttpGet]
        public DetailedAthlete GetDetailedAthleteById(int id)
        {
            return _athleteService.GetDetailedAthleteById(id);
        }
    }
}
