using Backend.Core.Models.Comment;

namespace Backend.Core.Models.Blog
{
    public class BlogResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string Username { get; set; }
        public List<CommentResponse> Comments { get; set; } = new List<CommentResponse>();
    }
}
