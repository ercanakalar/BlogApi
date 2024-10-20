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
        public async Task<IActionResult> UpdateBlog(int id, CreateBlogDto blogPostDto)
        {
            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound("Blog post not found.");
            }

            blogPost.Title = blogPostDto.Title;
            blogPost.Content = blogPostDto.Content;
            blogPost.UpdatedAt = DateTime.UtcNow;

            _context.Entry(blogPost).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return Ok(new
            {
                message = "You have successfully updated the blog.",
            });
        }
    }
}
