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
    [Migration("20200805135823_Identity-seed")]
    partial class Identityseed
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
                    b.Property<string>("CategoryID")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

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
                            CategoryID = "Tom1",
                            CategoryName = "Chaos;Head",
                            CreateDate = new DateTime(2020, 8, 5, 20, 58, 22, 682, DateTimeKind.Local).AddTicks(4644)
                        },
                        new
                        {
                            CategoryID = "Tom2",
                            CategoryName = "Chaos;Child",
                            CreateDate = new DateTime(2020, 8, 5, 20, 58, 22, 684, DateTimeKind.Local).AddTicks(1319)
                        },
                        new
                        {
                            CategoryID = "Tom3",
                            CategoryName = "Steins;Gate",
                            CreateDate = new DateTime(2020, 8, 5, 20, 58, 22, 684, DateTimeKind.Local).AddTicks(1353)
                        },
                        new
                        {
                            CategoryID = "Tom4",
                            CategoryName = "Robotics;Notes",
                            CreateDate = new DateTime(2020, 8, 5, 20, 58, 22, 684, DateTimeKind.Local).AddTicks(1356)
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
                            CommentID = "hoho1",
                            CommentTime = new DateTime(2020, 8, 5, 20, 58, 22, 686, DateTimeKind.Local).AddTicks(8331),
                            Commentator = "Đẹp trai vô danh",
                            Commenter = "Bài review rất hay",
                            PostID = "Chaos;Head1",
                            UserID = new Guid("00000000-0000-0000-0000-000000000000")
                        },
                        new
                        {
                            CommentID = "hoho2",
                            CommentTime = new DateTime(2020, 8, 5, 20, 58, 22, 686, DateTimeKind.Local).AddTicks(9803),
                            Commentator = "Bá đạo trên từng hạt gạo",
                            Commenter = "Bài review rất tệ",
                            PostID = "Chaos;Child1",
                            UserID = new Guid("00000000-0000-0000-0000-000000000000")
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Post", b =>
                {
                    b.Property<string>("PostID")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("CategoryID")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

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
                            CategoryID = "Tom2",
                            Contents = "Đây là 1 Visual Novel rất hay",
                            PostName = "Review Visual Novel Chaos;Child",
                            Thumbnail = "https://images-na.ssl-images-amazon.com/images/I/91HUMu2XDYL._RI_.jpg",
                            UserID = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                            View = 0,
                            WriteTime = new DateTime(2020, 8, 5, 20, 58, 22, 685, DateTimeKind.Local).AddTicks(9448)
                        },
                        new
                        {
                            PostID = "Chaos;Head1",
                            CategoryID = "Tom1",
                            Contents = "Đây là 1 Visual Novel rất hay",
                            PostName = "Review Visual Novel Chaos;Head",
                            Thumbnail = "https://upload.wikimedia.org/wikipedia/vi/3/34/Chaos_Head_game_cover.jpg",
                            UserID = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                            View = 0,
                            WriteTime = new DateTime(2020, 8, 5, 20, 58, 22, 686, DateTimeKind.Local).AddTicks(2950)
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.PostTag", b =>
                {
                    b.Property<string>("TagID")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

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
                            TagID = "kiki1",
                            PostID = "Chaos;Head1"
                        },
                        new
                        {
                            TagID = "kiki2",
                            PostID = "Chaos;Head1"
                        },
                        new
                        {
                            TagID = "kiki1",
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
                            ConcurrencyStamp = "19633fd3-b66f-4b47-ba9c-078a3f9f777f",
                            Name = "admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                            ConcurrencyStamp = "94188c0a-56e0-4ab7-8052-ce00c6241d89",
                            Name = "Writer",
                            NormalizedName = "Writer"
                        });
                });

            modelBuilder.Entity("AdvWeb_VN.Data.Entities.Tag", b =>
                {
                    b.Property<string>("TagID")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

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
                            TagID = "kiki1",
                            TagName = "Visual Novel"
                        },
                        new
                        {
                            TagID = "kiki2",
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
                            ConcurrencyStamp = "015746f4-927c-46a4-8243-05e2f778c17e",
                            Email = "hoangthuan2092003@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hoangthuan2092003@gmail.com",
                            NormalizedUserName = "admin",
                            PasswordHash = "AQAAAAEAACcQAAAAEJon30keugd4YPgX6aDwoQ3q27YeKlF1aU16zGPja5tgbCyvQQyBqg3JZsFvp/nlVw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3d5a0fb4-ba7e-4113-9c66-caf29eeda7cc",
                            Email = "hoangthuan2092003@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hoangthuan2092003@gmail.com",
                            NormalizedUserName = "hoho303",
                            PasswordHash = "AQAAAAEAACcQAAAAEDrIvmoCKu33p2/ZMif1QwybaVogq83wvLD+G296vNSslLn8m5fEGT4/3Ulsi8M7hg==",
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
