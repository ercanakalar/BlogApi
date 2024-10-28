using Backend.Core.Models.Comment;

namespace Backend.Core.Repositories
{
    public interface ICommentRepository: IRepository<Comment>
    {
        Task CreateComment(CommentRequest commentRequest);
    }
}
