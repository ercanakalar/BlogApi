using Backend.Core.Models.Comment;
using Backend.Core.Services;
using Backend.Core.UnitOfWorks;
using Backend.Data.UnitOfWorks;

namespace Backend.Service.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Comment> CreateComment(CommentRequest request)
        {
            var comment = new Comment
            {
                UserId = request.UserId,
                BlogId = request.BlogId,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Content = request.Content,
            };

            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.CommitAsync();

            return comment;
        }
    }
}
