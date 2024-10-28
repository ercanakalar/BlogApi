using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend.Core.Models.User;
using Backend.Core.Services;
using Backend.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newUser = await _userService.Signup(request);
            if (newUser.IsSuccess == false)
            {
                return BadRequest(newUser);
            }
            return Ok(newUser);
        }

        [HttpPost("signin")]
        public async Task<IActionResult> Signin([FromBody] SigninRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.Signin(request);
            if (user.IsSuccess == false)
            {
                return BadRequest(user);
            }

            return Ok(user);
        }
    }
}
