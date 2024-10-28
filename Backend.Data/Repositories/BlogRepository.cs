using System.Threading.Tasks;
using Backend.Core.Models.Blog;

namespace Backend.Data.Repositories
{
    public class BlogRepository
    {
        private readonly AppDbContext _context;

        public BlogRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateBlog(BlogRequest request)
        {
            var blog = new Blog
            {
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();
        }
    }
}
