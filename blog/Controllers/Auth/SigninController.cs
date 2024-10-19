using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Blog.Data;
using Blog.Service.IService;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/auth/signin")]
    public class SigninController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordManager _passwordManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public SigninController(
            ApplicationDbContext context,
            PasswordManager passwordManager,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _passwordManager = passwordManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn([FromBody] UserSigninDto dto)
        {
            if (dto == null || string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Password))
                return BadRequest("Invalid login request.");

            var user = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null)
                return Unauthorized("Invalid credentials.");

            var isPasswordValid = _passwordManager.VerifyPassword(user.Password, dto.Password);
            if (!isPasswordValid)
                return Unauthorized("Invalid credentials.");

            var roles = new List<string> { user.Role };
            var authJwt = _jwtTokenGenerator.GenerateToken(user, roles);

            Response.Cookies.Append("auth", authJwt, new CookieOptions
            {
                HttpOnly = true
            });

            Response.Headers.Append("Authorization", $"Bearer {authJwt}");

            return Ok(new
            {
                message = "Login successful.",
                data = new
                {
                    user.Id,
                    user.UserName,
                    user.Email
                },
                token = authJwt
            });
        }
    }
}