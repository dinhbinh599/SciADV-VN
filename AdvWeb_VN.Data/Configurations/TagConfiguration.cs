using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Configurations
{
	public class TagConfiguration : IEntityTypeConfiguration<Tag>
	{
		public void Configure(EntityTypeBuilder<Tag> builder)
		{
			builder.ToTable("Tags");
			builder.HasKey(x => x.TagID);
			builder.Property(x => x.TagID).UseIdentityColumn();
			builder.Property(x => x.TagName).IsRequired()
				.IsUnicode().HasMaxLength(100);
		}
	}
}
