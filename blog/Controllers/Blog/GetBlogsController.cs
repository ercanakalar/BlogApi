using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/blog")]
    public class BlogPostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BlogPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogPost>>> GetAllBlogs()
        {
            var blogPosts = await _context.BlogPosts
                .Include(b => b.Comments)  // Include related comments
                .ToListAsync();

            return Ok(blogPosts);
        }
    }
}
