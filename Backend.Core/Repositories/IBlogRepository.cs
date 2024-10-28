using Backend.Core.Models.Blog;
using Backend.Core.Repositories;

namespace Backend.Core.Repositories
{
    public interface IBlogRepository : IRepository<Blog>
    {
        Task CreateBlog(BlogRequest request);
    }
}
