using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/blog")]
    public class GetBlogAllController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GetBlogAllController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetAllBlogs()
        {
            var blogPosts = await _context.BlogPosts
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
                .ToListAsync();

            return Ok(blogPosts);
        }
    }
}
