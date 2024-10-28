using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Backend.Core.Models.Blog;
using Backend.Core.Services;
using Backend.Core.UnitOfWorks;
using Backend.Data.UnitOfWorks;

namespace Backend.Service.Services
{
    public class BlogService : Service<Blog>, IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
            : base(unitOfWork, unitOfWork.Blogs)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BlogResponse> CreateBlog(BlogRequest request)
        {
            var blog = new Blog
            {
                Title = request.Title,
                Content = request.Content,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            await _unitOfWork.Blogs.AddAsync(blog);
            await _unitOfWork.CommitAsync();

            return new BlogResponse
            {
                ID = blog.ID,
                Title = blog.Title,
                Content = blog.Content,
                CreatedAt = blog.CreatedAt,
                UpdatedAt = blog.UpdatedAt,
                Username = blog.Users?.FirstOrDefault()?.Username,
                Comments =
                    blog.Comments?.Select(c => new CommentResponse
                        {
                            Id = c.Id,
                            Content = c.Content,
                            CreatedAt = c.CreatedAt,
                            Username = c.Users.Username,
                        })
                        .ToList() ?? new List<CommentResponse>(),
            };
        }
    }
}
