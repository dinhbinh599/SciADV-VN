using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Configurations
{
	public class PostConfiguration : IEntityTypeConfiguration<Post>
	{
		public void Configure(EntityTypeBuilder<Post> builder)
		{
			//Cài đặt cấu hình bảng cho Post (One To Many)
			//Một chuyên mục con có thể có nhiều bài viết nhưng 1 bài viết chỉ thuộc 1 chuyên mục con
			//Một User có thể viết nhiều bài viết nhưng 1 bài viết chỉ thuộc về 1 User
			builder.ToTable("Posts");
			builder.HasKey(x => x.PostID);
			builder.Property(x => x.PostID).UseIdentityColumn();
			builder.Property(x => x.Thumbnail).IsRequired().HasMaxLength(200);
			builder.Property(x => x.PostName).IsRequired()
				.HasMaxLength(200).IsUnicode();
			builder.Property(x => x.Contents).IsRequired().IsUnicode();
			builder.Property(x => x.Summary).HasMaxLength(255).IsUnicode();
			builder.Property(x => x.View).IsRequired().HasDefaultValue(0);
			builder.Property(x => x.IsShow).IsRequired().HasDefaultValue(true);
			builder.HasOne(x => x.SubCategory).WithMany(x => x.Posts).HasForeignKey(x => x.SubCategoryID);
			builder.HasOne(x => x.User).WithMany(x => x.Posts).HasForeignKey(x => x.UserID);
		}
	}
}
