using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blog.Data;
using Blog.Models;
using System.Security.Claims;

namespace Blog.Controllers
{
    [ApiController]
    [Route("api/blog")]
    [Authorize]
    public class CreateBlogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CreateBlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<BlogPost>> CreateBlog(CreateBlogDto createBlogDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
                return Unauthorized("User is not authenticated");

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == int.Parse(userId));
            if (user == null)
            {
                return NotFound("User does not exist.");
            }

            var blogPost = new BlogPost
            {
                Title = createBlogDto.Title,
                Content = createBlogDto.Content,
                UserId = int.Parse(userId),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.BlogPosts.Add(blogPost);
            await _context.SaveChangesAsync();

            return Ok(new
            {
                blogPost.ID,
                blogPost.Title,
                blogPost.Content,
                blogPost.CreatedAt,
                blogPost.UpdatedAt,
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
