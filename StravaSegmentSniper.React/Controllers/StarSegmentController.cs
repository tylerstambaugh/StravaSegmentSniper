using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Services.Internal.Models.Segment;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StarSegmentController
    {
        public StarSegmentController()
        {
            
        }

        [HttpPost]
        public StarSegmentModel StarSegment(long segmentId)
        {
            throw new NotImplementedException();
        }

    }
}
