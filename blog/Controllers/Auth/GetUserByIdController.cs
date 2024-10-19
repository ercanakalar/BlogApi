using Blog.Data;
using Microsoft.AspNetCore.Mvc;

namespace Blog;

[ApiController]
[Route("api/auth/[action]")]
public class GetUserByIdController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public GetUserByIdController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet("{id}")]
    [ActionName("get-user-by-id")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _context.Users.FindAsync(id);
        
        if (user == null)
            return BadRequest("User not found.");
        return Ok(user);
    }
}

