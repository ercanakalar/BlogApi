using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Models.Blog
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Backend.Core.Models.User.User> Users { get; set; }

        public ICollection<Backend.Core.Models.Comment.Comment> Comments { get; set; }
    }
}
