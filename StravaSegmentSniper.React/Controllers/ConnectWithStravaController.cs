using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConnectWithStravaController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConnectWithStravaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //[ActionName("GetClientId")]
        public IActionResult GetClientId()
        {
            return Ok(_configuration.GetSection("StravaAPICodes:ClientId"));
        }

        [HttpPost]
        public IActionResult PostAuthorizationCode()
        {
            return BadRequest();
        }
    }
}
