using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Services.Internal.Services;
using System.Security.Claims;


namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AthleteController : ControllerBase
    {
        private readonly IAthleteService _athleteService;
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AthleteController(IAthleteService athleteService, IWebAppUserService webAppUserService)
        {
            _athleteService = athleteService;
            _webAppUserService = webAppUserService;
        }

        [HttpGet]
        public IEnumerable<DetailedAthlete> GetDetailedAthletes()
        {
            return _athleteService.GetDetailedAthletes();
        }

        [HttpGet("{id}")]
        public DetailedAthlete GetDetailedAthleteById(long id)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var user = _webAppUserService.GetLoggedInUserById(userId);
            var athleteId = user.StravaAthleteId;
            return _athleteService.GetDetailedAthleteById((int)athleteId);
        }
    }
}
