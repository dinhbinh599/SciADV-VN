using AdvWeb_VN.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdvWeb_VN.Data.Extensions
{
	public static class ModelBuilderExtension
	{
		public static void Seed(this ModelBuilder modelBuilder)
		{
			var ROLE_ID = new Guid("706A7F4F-A6ED-4E24-BD09-DF7829865142");
			var ROLE_ID2 = new Guid("D00409DB-A6ED-4985-A3B7-4036774572CD");
			var WRITER_ID = new Guid("5581E8DC-2614-4392-A95C-2E9411BFDB14");
			var ADMIN_ID = new Guid("0CFE64BD-645B-4F5A-91D1-C3082C132ED8");
			modelBuilder.Entity<Category>().HasData(
				new Category()
				{
					CategoryID = 1,
					CategoryName = "News",
					CreateDate = DateTime.Now,
				},
				new Category()
				{
					CategoryID = 2,
					CategoryName = "Review",
					CreateDate = DateTime.Now,

				},
				new Category()
				{
					CategoryID = 3,
					CategoryName = "Project",
					CreateDate = DateTime.Now
				},
				new Category()
				{
					CategoryID = 4,
					CategoryName = "Donate",
					CreateDate = DateTime.Now
				});
			modelBuilder.Entity<SubCategory>().HasData(
				new SubCategory()
				{
					SubCategoryID = 1,
					CategoryName = "Chaos;Head",
					CreateDate = DateTime.Now,
					CategoryID = 1
				},
				new SubCategory()
				{
					SubCategoryID = 2,
					CategoryName = "Chaos;Child",
					CreateDate = DateTime.Now,
					CategoryID = 1

				},
				new SubCategory()
				{
					SubCategoryID = 3,
					CategoryName = "Steins;Gate",
					CreateDate = DateTime.Now,
					CategoryID = 1
				},
				new SubCategory()
				{
					SubCategoryID = 4,
					CategoryName = "Chaos;Child",
					CreateDate = DateTime.Now,
					CategoryID = 2
				},
				new SubCategory()
				{
					SubCategoryID = 5,
					CategoryName = "Chaos;Head",
					CreateDate = DateTime.Now,
					CategoryID = 3
				});

			/*modelBuilder.Entity<Post>().HasData(
				new Post()
				{
					PostID = "News-Chaos;Child1",
					PostName = "Review Visual Novel Chaos;Child",
					WriteTime = DateTime.Now,
					Contents = "Đây là 1 Visual Novel rất hay",
					Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/91HUMu2XDYL._RI_.jpg",
					UserID = WRITER_ID,
					SubCategoryID = 2
				},
				new Post()
				{
					PostID = "Chaos;Head1",
					PostName = "Review Visual Novel Chaos;Head",
					WriteTime = DateTime.Now,
					Contents = "Đây là 1 Visual Novel rất hay",
					Thumbnail = "https://upload.wikimedia.org/wikipedia/vi/3/34/Chaos_Head_game_cover.jpg",
					UserID = WRITER_ID,
					SubCategoryID = 1
				});*/
			modelBuilder.Entity<Tag>().HasData(
				new Tag()
				{
					TagID = 1,
					TagName = "Visual Novel",
				},
				new Tag()
				{
					TagID = 2,
					TagName = "Chaos;Head"
				});
			/*
			modelBuilder.Entity<Comment>().HasData(
				new Comment()
				{ 
					CommentID = "Chaos;Head1-1",
					Commentator = "Đẹp trai vô danh",
					Commenter = "Bài review rất hay",
					CommentTime = DateTime.Now,
					PostID = "Chaos;Head1"
				},
				new Comment()
				{
					CommentID = "Chaos;Head1-2",
					Commentator = "Đẹp trai có danh",
					Commenter = "Ừ bài hay thật",
					ParrentID = "Chaos;Head1-1",
					CommentTime = DateTime.Now,
					PostID = "Chaos;Head1"
				},
				new Comment()
				{
					CommentID = "Chaos;Head1-3",
					Commentator = "hoho303",
					Commenter = "Cảm ơn các bạn",
					ParrentID = "Chaos;Head1-1",
					UserID = WRITER_ID,
					CommentTime = DateTime.Now,
					PostID = "Chaos;Head1"
				},
				new Comment()
				{
					CommentID = "Chaos;Child1-1",
					Commentator = "Bá đạo trên từng hạt gạo",
					Commenter = "Bài review rất tệ",
					CommentTime = DateTime.Now,
					PostID = "Chaos;Child1"
				},
				new Comment()
				{
					CommentID = "Chaos;Child1-2",
					Commentator = "hoho303",
					Commenter = "Xin lỗi, mình sẽ cố gắng cải thiện!",
					ParrentID = "Chaos;Child1-1",
					CommentTime = DateTime.Now,
					UserID = WRITER_ID,
					PostID = "Chaos;Child1"
				});
			modelBuilder.Entity<PostTag>().HasData(
				new PostTag()
				{
					PostID = "Chaos;Head1",
					TagID = 2
				}, 
				new PostTag()
				{
					PostID = "Chaos;Head1",
					TagID = 1
				},
				new PostTag()
				{
					PostID = "Chaos;Child1",
					TagID = 1
				});
				*/

			modelBuilder.Entity<Role>().HasData(new Role()
			{
				Id = ROLE_ID,
				Name = "admin",
				NormalizedName = "admin"
			});

			modelBuilder.Entity<Role>().HasData(new Role()
			{
				Id = ROLE_ID2,
				Name = "Writer",
				NormalizedName = "Writer"
			});

			var hasher = new PasswordHasher<User>();

			modelBuilder.Entity<User>().HasData(new User()
			{
				Id = ADMIN_ID,
				UserName = "admin",
				NormalizedUserName = "admin",
				Email = "hoangthuan2092003@gmail.com",
				NormalizedEmail = "hoangthuan2092003@gmail.com",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "2092003"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<User>().HasData(new User()
			{
				Id = WRITER_ID,
				UserName = "hoho303",
				NormalizedUserName = "hoho303",
				Email = "hoangthuan2092003@gmail.com",
				NormalizedEmail = "hoangthuan2092003@gmail.com",
				EmailConfirmed = true,
				PasswordHash = hasher.HashPassword(null, "2092003"),
				SecurityStamp = string.Empty
			});

			modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
			{
				RoleId = ROLE_ID,
				UserId = ADMIN_ID
			});

			modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
			{
				RoleId = ROLE_ID2,
				UserId = WRITER_ID
			});
		}
	}
	
}
