﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 50, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    PostName = table.Column<string>(maxLength: 50, nullable: false),
                    WriteTime = table.Column<DateTime>(nullable: false),
                    Contents = table.Column<string>(nullable: false),
                    Thumbnail = table.Column<string>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    View = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentID = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Commentator = table.Column<string>(maxLength: 50, nullable: true),
                    Commenter = table.Column<string>(nullable: false),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    PostID = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    UserID = table.Column<Guid>(nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentID);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostID = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    TagID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.TagID, x.PostID });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagID",
                        column: x => x.TagID,
                        principalTable: "Tags",
                        principalColumn: "TagID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"), new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142") },
                    { new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), new Guid("d00409db-a6ed-4985-a3b7-4036774572cd") }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "CategoryName", "CreateDate" },
                values: new object[,]
                {
                    { 1, "Chaos;Head", new DateTime(2020, 8, 6, 14, 53, 22, 161, DateTimeKind.Local).AddTicks(8301) },
                    { 2, "Chaos;Child", new DateTime(2020, 8, 6, 14, 53, 22, 162, DateTimeKind.Local).AddTicks(8485) },
                    { 3, "Steins;Gate", new DateTime(2020, 8, 6, 14, 53, 22, 162, DateTimeKind.Local).AddTicks(8510) },
                    { 4, "Robotics;Notes", new DateTime(2020, 8, 6, 14, 53, 22, 162, DateTimeKind.Local).AddTicks(8514) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"), "0312de49-7acb-495e-97fb-d56e5ae0afb4", "admin", "admin" },
                    { new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"), "f0098992-d4e5-40d4-85bc-a033a18be13a", "Writer", "Writer" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagID", "TagName" },
                values: new object[,]
                {
                    { 1, "Visual Novel" },
                    { 2, "Chaos;Head" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"), 0, "328d7c38-3bbe-4e24-a8e8-bc796fe9fddb", "hoangthuan2092003@gmail.com", true, false, null, "hoangthuan2092003@gmail.com", "admin", "AQAAAAEAACcQAAAAEGfqwSyKDVuZUcIU6uujMLvmllAyWpHSaSCflVBEMXg3ynCFIPL3eRADDx0UzuhWBA==", null, false, "", false, "admin" },
                    { new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), 0, "6e5faefa-79e2-4fc5-a9f8-7e9d19f49e75", "hoangthuan2092003@gmail.com", true, false, null, "hoangthuan2092003@gmail.com", "hoho303", "AQAAAAEAACcQAAAAEPrCyqTFJow+D01r/232kJqUVISKqGGDkOorfh2meJRO5PUBOnPw1O4uCA3zNuIBGQ==", null, false, "", false, "hoho303" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "CategoryID", "Contents", "PostName", "Thumbnail", "UserID", "WriteTime" },
                values: new object[] { "Chaos;Child1", 2, "Đây là 1 Visual Novel rất hay", "Review Visual Novel Chaos;Child", "https://images-na.ssl-images-amazon.com/images/I/91HUMu2XDYL._RI_.jpg", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), new DateTime(2020, 8, 6, 14, 53, 22, 164, DateTimeKind.Local).AddTicks(2869) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "CategoryID", "Contents", "PostName", "Thumbnail", "UserID", "WriteTime" },
                values: new object[] { "Chaos;Head1", 1, "Đây là 1 Visual Novel rất hay", "Review Visual Novel Chaos;Head", "https://upload.wikimedia.org/wikipedia/vi/3/34/Chaos_Head_game_cover.jpg", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), new DateTime(2020, 8, 6, 14, 53, 22, 164, DateTimeKind.Local).AddTicks(5235) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "PostID" },
                values: new object[,]
                {
                    { "hoho2", new DateTime(2020, 8, 6, 14, 53, 22, 164, DateTimeKind.Local).AddTicks(9756), "Bá đạo trên từng hạt gạo", "Bài review rất tệ", "Chaos;Child1" },
                    { "hoho1", new DateTime(2020, 8, 6, 14, 53, 22, 164, DateTimeKind.Local).AddTicks(8764), "Đẹp trai vô danh", "Bài review rất hay", "Chaos;Head1" }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "TagID", "PostID" },
                values: new object[,]
                {
                    { 1, "Chaos;Child1" },
                    { 2, "Chaos;Head1" },
                    { 1, "Chaos;Head1" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryID",
                table: "Posts",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostID",
                table: "PostTags",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}