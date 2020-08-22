using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Configurations
{
	public class CommentConfiguration : IEntityTypeConfiguration<Comment>
	{
		public void Configure(EntityTypeBuilder<Comment> builder)
		{
			builder.ToTable("Comments");
			builder.HasKey(x => x.CommentID);
			builder.Property(x => x.CommentID).IsUnicode().HasMaxLength(100);
			builder.Property(x => x.ParrentID).IsUnicode().HasMaxLength(100);
			builder.Property(x => x.UserID).HasDefaultValue(Guid.Empty);
			builder.Property(x => x.Commenter).IsRequired().IsUnicode();
			builder.Property(x => x.Commentator).IsRequired(false).HasMaxLength(50).IsUnicode();
			builder.Property(x => x.PostID).IsRequired().IsUnicode().HasMaxLength(100);
			builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostID);
			//builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserID);
		}
	}
}
