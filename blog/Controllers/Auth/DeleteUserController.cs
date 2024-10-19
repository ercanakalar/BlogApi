using Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Blog;

[ApiController]
[Route("api/auth/[action]")]
public class DeleteUserController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public DeleteUserController(ApplicationDbContext context)
    {
        _context = context;
    }
    [Authorize]
    [HttpDelete("{id}")]
    [ActionName("delete-user")]
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
        var userToDelete = await _context.Users.FindAsync(id);
        if (userToDelete == null)
            return BadRequest("Hero not found.");

        _context.Users.Remove(userToDelete);
        await _context.SaveChangesAsync();

        return Ok(await _context.Users.ToListAsync());
    }
}
