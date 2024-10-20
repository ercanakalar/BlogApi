using Microsoft.EntityFrameworkCore;
using Blog.Models;

namespace Blog.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the BlogPost entity
            modelBuilder.Entity<BlogPost>()
                .ToTable("BlogPost")
                .HasMany(b => b.Comments)
                .WithOne(c => c.BlogPost) // Establish the inverse relationship
                .HasForeignKey(c => c.BlogId); // Specify the foreign key

            // Configure the User entity
            modelBuilder.Entity<User>().ToTable("Users");

            // Configure the Comment entity
            modelBuilder.Entity<Comment>().ToTable("Comments");
        }
    }
}
