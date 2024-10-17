using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class BlogPost
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
