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
    [Route("api/auth/signup")]
    public class SignupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly PasswordManager _passwordManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public SignupController(
            ApplicationDbContext context,
            PasswordManager passwordManager,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _passwordManager = passwordManager;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        [HttpPost]
        public async Task<IActionResult> Signup([FromBody] UserRegistrationDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid user data.");

            var existingUser = await _context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (existingUser != null)
                return BadRequest("Email in use");

            if (!dto.Password.Equals(dto.ConfirmPassword))
                return BadRequest("Passwords do not match");

            var hashedPassword = _passwordManager.HashPassword(dto.Password);
            var hashedConfirmPassword = _passwordManager.HashPassword(dto.Password);
            Console.WriteLine(dto.Role);
            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                Password = hashedPassword,
                ConfirmPassword = hashedConfirmPassword,
                Role = dto.Role ?? "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var roles = new List<string> { user.Role };
            var authJwt = _jwtTokenGenerator.GenerateToken(user, roles);
            var expireToken = _jwtTokenGenerator.GenerateExpiredToken(user, roles);

            user.ExpireToken = expireToken;

            _context.Users.Update(user);
            await _context.SaveChangesAsync();

            Response.Cookies.Append("auth", authJwt, new CookieOptions
            {
                HttpOnly = true
            });

            Response.Headers.Append("Authorization", $"Bearer {authJwt}");

            return Ok(new
            {
                message = "You have successfully registered.",
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