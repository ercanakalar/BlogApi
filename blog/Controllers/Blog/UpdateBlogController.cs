using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/blog")]
    [Authorize]
    public class UpdateBlogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UpdateBlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(int id, BlogPost blogPost)
        {
            Console.WriteLine(id);
            if (id != blogPost.ID)
            {
                return BadRequest();
            }

            blogPost.UpdatedAt = DateTime.UtcNow;
            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

             return Ok(new
            {
                message = "You have successfully updated the blog.",
            });
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.ID == id);
        }
    }
}
