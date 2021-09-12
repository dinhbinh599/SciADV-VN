using AdvWeb_VN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvWeb_VN.Data.Configurations
{
	public class PostTagConfiguration : IEntityTypeConfiguration<PostTag>
	{
		public void Configure(EntityTypeBuilder<PostTag> builder)
		{
			//Cài đặt cấu hình bảng cho PostTag (Many to Many)
			//Một bài viết có thể có nhiều Tag
			//Một Tag có thể xuất hiện ở nhiều bài viết
			builder.ToTable("PostTags");
			builder.HasKey(x => new { x.TagID, x.PostID });
			builder.HasOne(x => x.Post).WithMany(t => t.PostTags)
				.HasForeignKey(t => t.PostID);
			builder.HasOne(x => x.Tag).WithMany(t => t.PostTags)
				.HasForeignKey(t => t.TagID);
		}
	}
}