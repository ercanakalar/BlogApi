using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
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
        public BlogPost BlogPost { get; set; }
    }
}
