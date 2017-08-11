using CityWeatherService.Interfaces;
using CityWeatherService.Model.EntityModels;
using System.Threading.Tasks;
using System.Web.Http;

namespace WarmSide.WebApi.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("addUser")]
        [HttpPost]
        public async Task<IHttpActionResult> AddUser([FromBody]CityWeatherService.Model.EntityModels.User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _userService.AddUser(user);

            return Ok();
        }

        [Route("getUser/{userId}")]
        [HttpGet]
        public async Task<IHttpActionResult> GetUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var user = await _userService.FindUser(userId);

            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        [Route("updateUser")]
        [HttpPost]
        public async Task<IHttpActionResult> UpdateUser(User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            await _userService.UpdateUser(user);

            return Ok();
        }
    }
}