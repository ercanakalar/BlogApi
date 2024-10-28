namespace Backend.Core.Models.Comment
{
    public class CommentRequest
    {
        public int BlogId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
