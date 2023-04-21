using Authorization.Data.Models;
using Azure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StravaSegmentSniper.Data.Entities.User;
using StravaSegmentSniper.Services.Internal.Services;
using System.Security.Claims;
using NuGet.Protocol;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StravaSegmentSniper.React.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IWebAppUserService _webAppUserService;
        private readonly UserManager<WebAppUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserController(IWebAppUserService webAppUserService, UserManager<WebAppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _webAppUserService = webAppUserService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public WebAppUser GetUser()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            // var user = await _userManager.GetUserIdAsync(User)
            return _webAppUserService.GetLoggedInUserById(userId);
        }

        //// GET: api/<UserController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<UserController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<UserController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
