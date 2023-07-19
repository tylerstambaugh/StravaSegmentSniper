using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.React.ActionHandlers.StravaApiToken;
//using System.Web.Http;

namespace StravaSegmentSniper.React.Controllers
{

    [Authorize]
    [Route("api/[controller]/[action]/")]
    [ApiController]
    public class ConnectWithStravaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IExchangeAuthCodeForTokenHandler _exchangeAuthCodeForTokenHandler;

        public ConnectWithStravaController(IConfiguration configuration, IExchangeAuthCodeForTokenHandler exchangeAuthCodeForTokenHandler)
        {
            _configuration = configuration;
            _exchangeAuthCodeForTokenHandler = exchangeAuthCodeForTokenHandler;
        }

        [HttpGet]
        //[ActionName("GetClientId")]
        public IActionResult GetClientId()
        {
            return Ok(new ClientIdResponse
            {
                ClientId = _configuration.GetSection("StravaAPICodes:ClientId").Value
            }
            );
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        //[ActionName("ExchangeToken/")]
        public IActionResult ExchangeToken(string id, [System.Web.Http.FromUri] string code, [System.Web.Http.FromUri] string scope)
        {
            ExchangeAuthCodeForTokenContract contract = new ExchangeAuthCodeForTokenContract
            {
                UserId = id,
                AuthCode = code,
                Scopes = scope,
            };

            var handleSuccess = _exchangeAuthCodeForTokenHandler.Execute(contract).Result;

            if (handleSuccess.TokenWasAdded)
            {
                string url = "https://localhost:44411/connect-with-strava-success";
                return Redirect(url);
            }
            else
            {
                string url = "https://localhost:44411/connect-with-strava-error";
                return Redirect(url);
            }
        }

    }
}
