using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class Segment : ControllerBase
    {
        public Segment()
        {

        }

        // GET api/<Segment>/5
        [HttpGet("{id}")]
        public Segment Get(int id)
        {
            return new Segment();
        }
    }
}
