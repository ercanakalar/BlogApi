using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Blog.Data;
namespace Blog.Models
{
    public class BlogPost
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public User User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}