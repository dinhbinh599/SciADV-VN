using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Configurations
{
	public class RoleConfiguration : IEntityTypeConfiguration<Role>
	{
		public void Configure(EntityTypeBuilder<Role> builder)
		{
			//Cài đặt cấu hình bảng cho Role
			builder.ToTable("Roles");
			builder.HasKey(x => x.Id);
		}
	}
}
