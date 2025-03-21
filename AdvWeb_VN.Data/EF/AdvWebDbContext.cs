﻿using AdvWeb_VN.Data.Configurations;
using AdvWeb_VN.Data.Entities;
using AdvWeb_VN.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace AdvWeb_VN.Data.EF;

public class AdvWebDbContext : IdentityDbContext<User,Role,Guid>
{
	public AdvWebDbContext(DbContextOptions options) : base(options)
	{
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		//Thiết lập thêm tùy chỉnh cho các bảng
		modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
		modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x=> new { x.UserId, x.RoleId});
		modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x=>x.UserId);
		modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
		modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => x.UserId);
		
		modelBuilder.Seed();
		//base.OnModelCreating(modelBuilder);
	}
	//Thiết lập DbSet để sau truy vấn đối tượng
	public DbSet<Post> Posts { set; get; }
	public DbSet<Category> Categories { set; get; }
	public DbSet<Comment> Comments { set; get; }
	public DbSet<Tag> Tags { set; get; }
	public DbSet<PostTag> PostTags { set; get; }
	public DbSet<PostImage> PostImages { set; get; }
	public DbSet<SubCategory> SubCategories { set; get; }
}

