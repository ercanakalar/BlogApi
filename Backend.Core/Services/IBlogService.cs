using System.Threading.Tasks;
using Backend.Core.Models.Blog;

namespace Backend.Core.Services
{
    public interface IBlogService
    {
        Task<BlogResponse> CreateBlog(BlogRequest request);
    }
}
