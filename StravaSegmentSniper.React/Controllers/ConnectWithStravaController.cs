using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using StravaSegmentSniper.React.ActionHandlers.StravaApiToken;

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
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
        [HttpGet]
        [ActionName("PostExchangeToken")]
        public  IActionResult PostExchangeToken(string code, string scope)
        {
            ExchangeAuthCodeForTokenContract contract = new ExchangeAuthCodeForTokenContract
            {
               AuthCode = code,
               Scopes = scope,
            };

            //call handler to handle response
            var handleSuccess = _exchangeAuthCodeForTokenHandler.Execute(contract).Result;

            if (handleSuccess.TokenWasAdded)
            {
                string url = "https://localhost:44411/";
                return Redirect(url);

                //return Ok();
            }
            else { return BadRequest(); }
        }

    }
}
