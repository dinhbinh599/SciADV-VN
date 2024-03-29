﻿using AdvWeb_VN.Data.Entities;
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
			//Cài đặt cấu hình bảng cho Comment (One To Many)
			//Một bài viết có thể có nhiều Comment, nhưng 1 Comment chỉ thuộc 1 bài viết
			builder.ToTable("Comments");
			builder.HasKey(x => x.CommentID);
			builder.Property(x => x.CommentID).UseIdentityColumn();
			builder.Property(x => x.UserID).HasDefaultValue(Guid.Empty);
			builder.Property(x => x.ParentID).IsRequired().HasDefaultValue(0);
			builder.Property(x => x.LikeCount).IsRequired().HasDefaultValue(0);
			builder.Property(x => x.DislikeCount).IsRequired().HasDefaultValue(0);
			builder.Property(x => x.Commenter).IsRequired().IsUnicode(); 
			builder.Property(x => x.IsManaged).IsRequired().HasDefaultValue(false);
			builder.Property(x => x.IsView).IsRequired().HasDefaultValue(false);
			builder.Property(x => x.Commentator).IsRequired(false).HasMaxLength(50).IsUnicode();
			builder.Property(x => x.PostID).IsRequired();
			builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostID);
			//builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserID);
		}
	}
}
