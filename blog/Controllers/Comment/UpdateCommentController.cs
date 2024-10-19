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
    public class UpdateCommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UpdateCommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("{commentId}")]
        public async Task<ActionResult<Comment>> UpdateComment(int commentId, [FromBody] CreateComment createComment)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized("User is not authenticated");

            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
                return NotFound("Comment not found");

            if (comment.UserId != int.Parse(userId))
                return StatusCode(403, "You do not have permission to update this comment.");

            comment.Content = createComment.Content;
            comment.UpdatedAt = DateTime.UtcNow;

            _context.Comments.Update(comment);
            await _context.SaveChangesAsync();

            return Ok(comment);
        }
    }
}
