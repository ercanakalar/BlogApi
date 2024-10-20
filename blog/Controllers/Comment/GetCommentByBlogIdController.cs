using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/blog/comment")]
    public class GetCommentByBlogIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetCommentByBlogIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{blogId}")]
        public async Task<ActionResult<IEnumerable<Comment>>> GetCommentByBlogId(int blogId)
        {
            var blogPost = await _context.BlogPosts.FindAsync(blogId);
            if (blogPost == null)
            {
                return NotFound("Blog post not found.");
            }

            var comments = await _context.Comments
                .Where(c => c.BlogId == blogId)
                .Include(c => c.User)
                .Select(c => new
                {
                    c.Id,
                    c.Content,
                    c.CreatedAt,
                    c.UpdatedAt,
                    User = new
                    {
                        c.User.Id,
                        c.User.UserName,
                        c.User.Email
                    }
                })
                .ToListAsync();

            if (!comments.Any())
            {
                return NotFound("No comments found for this blog post.");
            }

            return Ok(comments);
        }
    }
}
