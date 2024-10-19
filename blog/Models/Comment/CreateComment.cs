using System.ComponentModel.DataAnnotations;

namespace Blog.Data
{
    public class CreateComment
    {
        [Required]
        public int BlogId { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
