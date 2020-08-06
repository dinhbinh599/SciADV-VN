using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvWeb_VN.Data.Configurations
{
	public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
	{
		public void Configure(EntityTypeBuilder<PostTag> builder)
		{
			builder.ToTable("PostTags");
			builder.Property(t => t.PostID).IsUnicode(false).HasMaxLength(100);
			builder.HasKey(x => new { x.TagID, x.PostID });
			builder.HasOne(x => x.Post).WithMany(t => t.PostTags)
				.HasForeignKey(t => t.PostID);
			builder.HasOne(x => x.Tag).WithMany(t => t.PostTags)
				.HasForeignKey(t => t.TagID);
		}
	}
}