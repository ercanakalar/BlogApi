using Blog.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Blog;

[ApiController]
[Route("api/auth/[action]")]
public class GetAllUsersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GetAllUsersController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [ActionName("users")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<List<User>>> GetAllUsers()
    {
        var currentUserRole = User.FindFirstValue(ClaimTypes.Role);
        Console.WriteLine(currentUserRole);
        if (currentUserRole != "Admin")
        {
            return Forbid("You do not have permission to access this resource.");
        }

        var users = await _context.Users.Select(user => new
        {
            user.Id,
            user.UserName,
            user.Email
        }).ToListAsync();
        return Ok(new
        {
            message = "Users retrieved successfully.",
            data = users
        });
    }
}
