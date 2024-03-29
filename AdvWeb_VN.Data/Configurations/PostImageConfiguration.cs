﻿using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Configurations
{
    public class PostImageConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            //Cài đặt cấu hình bảng cho PostImage (Many to Many)
            //Một bài viết có thể có nhiều hình ảnh
            //Mỗi hình ảnh lại có thể dùng ở nhiều bài viết khác nhau
            builder.ToTable("PostImages");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.ID).UseIdentityColumn();

            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Caption).HasMaxLength(200);
            builder.Property(x => x.PostID).IsRequired(true);
            builder.HasOne(x => x.Post).WithMany(x => x.PostImages).HasForeignKey(x => x.PostID);
        }
    }
}
