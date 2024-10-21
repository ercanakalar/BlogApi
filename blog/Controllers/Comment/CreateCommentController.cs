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
    public class CreateCommentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CreateCommentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Comment>> CreateComment([FromBody] CreateComment createComment)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized("User is not authenticated");
            
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            if (user == null)
            {
                return NotFound("User does not exist.");
            }

            var blogPost = await _context.BlogPosts.FindAsync(createComment.BlogId);
            if (blogPost == null)
                return NotFound("Blog post not found");

            var comment = new Comment
            {
                Content = createComment.Content,
                UserId = int.Parse(userId),
                BlogId = createComment.BlogId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                comment.Id,
                comment.Content,
                comment.CreatedAt,
                comment.UpdatedAt,
                User = new
                {
                    user.Id,
                    user.UserName,
                    user.Email
                }
               
            });
        }
    }
}
