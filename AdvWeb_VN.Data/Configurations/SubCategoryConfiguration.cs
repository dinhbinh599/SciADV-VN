using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Configurations
{
	public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
	{
		public void Configure(EntityTypeBuilder<SubCategory> builder)
		{
			//Cài đặt cấu hình bảng cho SubCategory (One To Many)
			//Một chuyên mục cha có thể chứa nhiều chuyên mục con
			builder.ToTable("SubCategories");
			builder.HasKey(x => x.SubCategoryID);
			builder.Property(x => x.SubCategoryID).UseIdentityColumn();
			builder.Property(x => x.CategoryName).IsRequired()
				.HasMaxLength(200).IsUnicode();
			builder.HasOne(x => x.Category).WithMany(x => x.SubCategories).HasForeignKey(x => x.CategoryID);
		}
	}
}
