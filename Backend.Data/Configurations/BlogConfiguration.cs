using System;
using System.Collections.Generic;
using System.Text;
using Backend.Core.Models.Blog;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.HasKey(k => k.ID);
            builder.Property(m => m.ID).HasColumnName("ID");
            builder.Property(m => m.Title).HasMaxLength(50);
            builder.Property(m => m.Content).HasMaxLength(2000);

            builder.ToTable("Blogs");
        }
    }
}
