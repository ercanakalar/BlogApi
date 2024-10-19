using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using System.Security.Claims;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/blog/comment")]
    [Authorize]
    public class DeleteCommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DeleteCommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpDelete("{commentId}")]
        public async Task<ActionResult> DeleteComment(int commentId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized("User is not authenticated");

            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
                return NotFound("Comment not found");

            if (comment.UserId != int.Parse(userId))
                return StatusCode(403, "You do not have permission to delete this comment.");

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
