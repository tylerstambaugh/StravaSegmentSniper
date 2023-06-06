using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StravaSegmentController : ControllerBase
    {
        public StravaSegmentController()
        {

        }

        // GET api/<Segment>/5
        [HttpGet("{id}")]
        public StravaSegmentController Get(int id)
        {
            return new StravaSegmentController();
        }
    }
}
