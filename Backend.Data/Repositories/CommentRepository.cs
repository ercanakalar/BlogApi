using System.Threading.Tasks;
using Backend.Core.Models.Comment;

namespace Backend.Data.Repositories
{
    public class CommentRepository
    {
        private readonly AppDbContext _context;

        public CommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateComment(CommentRequest request)
        {
            var comment = new Comment
            {
                Content = request.Content,
                UserId = request.UserId,
                BlogId = request.BlogId,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
        }
    }
}
