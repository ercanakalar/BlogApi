using System;
using System.Collections.Generic;
using System.Text;
using Backend.Core.Models.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(m => m.Id).HasColumnName("ID");
            builder.Property(m => m.Content).HasMaxLength(2000);

            builder.ToTable("Comments");
        }
    }
}
