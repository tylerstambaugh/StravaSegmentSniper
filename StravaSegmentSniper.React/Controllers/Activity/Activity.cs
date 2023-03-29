using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Services.Internal.Services;

namespace StravaSegmentSniper.React.Controllers.Activity
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class Activity : ControllerBase
    {
        private readonly IAthleteActivityService _athleteActivityService;

        public Activity(IAthleteActivityService athleteActivityService)
        {
            _athleteActivityService = athleteActivityService;
        }

        // GET api/<ActivityController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
