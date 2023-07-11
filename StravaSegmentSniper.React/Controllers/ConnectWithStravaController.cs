using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return Ok(_configuration.GetSection("StravaAPICodes:ClientId").Value);
        }

        [HttpPost]
        public IActionResult PostExchangeToken([System.Web.Http.FromUri] AuthCodeResponse authCodeResponse)
        {
            ExchangeAuthCodeForTokenContract contract = new ExchangeAuthCodeForTokenContract
            {
               AuthCode = authCodeResponse.AuthCode,
               Scopes = authCodeResponse.Scopes,
            };

            //call handler to handle response
            var handleSuccess = await _exchangeAuthCodeForTokenHandler.Execute(contract);

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
