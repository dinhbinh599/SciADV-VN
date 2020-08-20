﻿// <auto-generated />
using System;
using AdvWeb_VN.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AdvWeb_VN.Data.Migrations
{
    [DbContext(typeof(AdvWebDbContext))]
    [Migration("20200813022016_update-image")]
    partial class updateimage
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Chaos;Head",
                            CreateDate = new DateTime(2020, 8, 13, 9, 20, 14, 504, DateTimeKind.Local).AddTicks(6162)
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Chaos;Child",
                            CreateDate = new DateTime(2020, 8, 13, 9, 20, 14, 505, DateTimeKind.Local).AddTicks(7472)
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Steins;Gate",
                            CreateDate = new DateTime(2020, 8, 13, 9, 20, 14, 505, DateTimeKind.Local).AddTicks(7499)
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Robotics;Notes",
                            CreateDate = new DateTime(2020, 8, 13, 9, 20, 14, 505, DateTimeKind.Local).AddTicks(7502)
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Comment", b =>
                {
                    b.Property<string>("CommentID")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<DateTime>("CommentTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Commentator")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("Commenter")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("ParrentID")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("PostID")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValue(new Guid("00000000-0000-0000-0000-000000000000"));

                    b.HasKey("CommentID");

                    b.HasIndex("PostID");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            CommentID = "Chaos;Head1-1",
                            CommentTime = new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(2817),
                            Commentator = "Đẹp trai vô danh",
                            Commenter = "Bài review rất hay",
                            PostID = "Chaos;Head1",
                            UserID = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CommentID = "Chaos;Head1-2",
                            CommentTime = new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(4273),
                            Commentator = "Đẹp trai có danh",
                            Commenter = "Ừ bài hay thật",
                            ParrentID = "Chaos;Head1-1",
                            PostID = "Chaos;Head1",
                            UserID = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CommentID = "Chaos;Head1-3",
                            CommentTime = new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(4873),
                            Commentator = "hoho303",
                            Commenter = "Cảm ơn các bạn",
                            ParrentID = "Chaos;Head1-1",
                            PostID = "Chaos;Head1",
                            UserID = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14")
                        },
                        new
                        {
                            CommentID = "Chaos;Child1-1",
                            CommentTime = new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(4883),
                            Commentator = "Bá đạo trên từng hạt gạo",
                            Commenter = "Bài review rất tệ",
                            PostID = "Chaos;Child1",
                            UserID = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CommentID = "Chaos;Child1-2",
                            CommentTime = new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(4885),
                            Commentator = "hoho303",
                            Commenter = "Xin lỗi, mình sẽ cố gắng cải thiện!",
                            ParrentID = "Chaos;Child1-1",
                            PostID = "Chaos;Child1",
                            UserID = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14")
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Post", b =>
                {
                    b.Property<string>("PostID")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Contents")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("PostName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("View")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<DateTime>("WriteTime")
                        .HasColumnType("datetime2");

                    b.HasKey("PostID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("UserID");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            PostID = "Chaos;Child1",
                            CategoryID = 2,
                            Contents = "Đây là 1 Visual Novel rất hay",
                            PostName = "Review Visual Novel Chaos;Child",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/91HUMu2XDYL._RI_.jpg",
                            UserID = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                            View = 0,
                            WriteTime = new DateTime(2020, 8, 13, 9, 20, 14, 511, DateTimeKind.Local).AddTicks(5039)
                        },
                        new
                        {
                            PostID = "Chaos;Head1",
                            CategoryID = 1,
                            Contents = "Đây là 1 Visual Novel rất hay",
                            PostName = "Review Visual Novel Chaos;Head",
                            Thumbnail = "https://upload.wikimedia.org/wikipedia/vi/3/34/Chaos_Head_game_cover.jpg",
                            UserID = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                            View = 0,
                            WriteTime = new DateTime(2020, 8, 13, 9, 20, 14, 511, DateTimeKind.Local).AddTicks(7936)
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.PostImage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<long>("FileSize")
                        .HasColumnType("bigint");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("PostID")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("ID");

                    b.HasIndex("PostID");

                    b.ToTable("PostImages");
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.PostTag", b =>
                {
                    b.Property<int>("TagID")
                        .HasColumnType("int");

                    b.Property<string>("PostID")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("TagID", "PostID");

                    b.HasIndex("PostID");

                    b.ToTable("PostTags");

                    b.HasData(
                        new
                        {
                            TagID = 2,
                            PostID = "Chaos;Head1"
                        },
                        new
                        {
                            TagID = 1,
                            PostID = "Chaos;Head1"
                        },
                        new
                        {
                            TagID = 1,
                            PostID = "Chaos;Child1"
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                            ConcurrencyStamp = "4acd489b-bd02-479c-ac22-a582dc7c4919",
                            Name = "admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                            ConcurrencyStamp = "36d4e31a-a5f7-4e90-9d56-c74e48c135a6",
                            Name = "Writer",
                            NormalizedName = "Writer"
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TagName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.HasKey("TagID");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            TagID = 1,
                            TagName = "Visual Novel"
                        },
                        new
                        {
                            TagID = 2,
                            TagName = "Chaos;Head"
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Avatar")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5b1145d5-3e57-4ddc-9e3d-4b2c00420998",
                            Email = "hoangthuan2092003@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hoangthuan2092003@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEJnqS+XqacLwik5HWzJEr1+JqGmmILREfTjOD4bUD+7dGt9w/O5sSUkT7cuhfwtqFw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "636d7aed-25bf-4190-9876-a53c19dd0da2",
                            Email = "hoangthuan2092003@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hoangthuan2092003@gmail.com",
                            NormalizedUserName = "hoho303",
                            PasswordHash = "AQAAAAEAACcQAAAAEK9P54ByPdBag4iFfFowJcV1vC1CyPai9MKTda8dJZ7j1byLqf8PUgRAIIpB+3SsnA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "hoho303"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("AppUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.ToTable("AppUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                            RoleId = new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142")
                        },
                        new
                        {
                            UserId = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                            RoleId = new Guid("d00409db-a6ed-4985-a3b7-4036774572cd")
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("AppUserTokens");
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Comment", b =>
                {
                    b.HasOne("AdvWeb_VN.Data.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Post", b =>
                {
                    b.HasOne("AdvWeb_VN.Data.Entities.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvWeb_VN.Data.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.PostImage", b =>
                {
                    b.HasOne("AdvWeb_VN.Data.Entities.Post", "Post")
                        .WithMany("PostImages")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.PostTag", b =>
                {
                    b.HasOne("AdvWeb_VN.Data.Entities.Post", "Post")
                        .WithMany("PostTags")
                        .HasForeignKey("PostID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AdvWeb_VN.Data.Entities.Tag", "Tag")
                        .WithMany("PostTags")
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}