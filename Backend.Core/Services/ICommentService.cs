using Backend.Core.Models.Comment;

namespace Backend.Core.Services
{
    public interface ICommentService
    {
        Task<Comment> CreateComment(CommentRequest commentRequest);
    }
}
