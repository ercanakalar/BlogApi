using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models.Comment
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BlogId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [Required]
        public string Content { get; set; }

        public Backend.Core.Models.Blog.Blog Blogs { get; set; }
        public Backend.Core.Models.User.User Users { get; set; }
    }
}
