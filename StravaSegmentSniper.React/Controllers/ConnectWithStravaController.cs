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
        public IActionResult PostExchangeToken([System.Web.Http.FromUri] AuthCodeResponse authCodeResponse)
        {
            AuthCodeResponse response = new AuthCodeResponse
            {
                State = authCodeResponse.State,
                AuthCode = authCodeResponse.AuthCode,
                Scopes = authCodeResponse.Scopes,
            };

            //call handler to handle response

            if (response.AuthCode != null)
            {
                return Ok();
            }
            else { return BadRequest(); }
        }

        public class AuthCodeResponse
        {
            public string State { get; set; }
            public string AuthCode { get; set; }
            public string Scopes { get; set; }
        }
    }
}
