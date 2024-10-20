using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/blog")]
    public class GetBlogByIdController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetBlogByIdController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPost>> GetBlogById(int id)
        {
            var blogPost = await _context.BlogPosts
                .Where(c => c.ID == id)
                .Include(b => b.Comments)
                .Select(b => new 
                {
                    b.ID,
                    b.Title,
                    b.Content,
                    b.CreatedAt,
                    b.UpdatedAt,
                    User = new 
                    {
                        b.User.Id,
                        b.User.UserName,
                        b.User.Email
                    },
                    Comments = b.Comments.Select(c => new 
                    {
                        c.Id,
                        c.Content,
                        c.CreatedAt,
                        c.UpdatedAt,
                        User = new 
                        {
                            b.User.Id,
                            b.User.UserName,
                            b.User.Email
                        },
                    })
                })
                .FirstOrDefaultAsync();

            if (blogPost == null)
            {
                return NotFound("Blog post not found.");
            }

            return Ok(blogPost);
        }
    }
}
