using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Categories");
			builder.HasKey(x => x.CategoryID);
			builder.Property(x => x.CategoryID).UseIdentityColumn();
			builder.Property(x => x.CategoryName).IsRequired()
				.HasMaxLength(200).IsUnicode();
		}
	}
}
