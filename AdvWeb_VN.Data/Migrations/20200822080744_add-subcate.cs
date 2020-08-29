using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class addsubcate : Migration
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
                    CategoryName = table.Column<string>(maxLength: 200, nullable: false),
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Avatar = table.Column<string>(unicode: false, maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(maxLength: 200, nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryID);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<string>(maxLength: 100, nullable: false),
                    PostName = table.Column<string>(maxLength: 200, nullable: false),
                    WriteTime = table.Column<DateTime>(nullable: false),
                    Contents = table.Column<string>(nullable: false),
                    Thumbnail = table.Column<string>(maxLength: 200, nullable: false),
                    SubCategoryID = table.Column<int>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    View = table.Column<int>(nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_SubCategories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryID",
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
                    CommentID = table.Column<string>(maxLength: 100, nullable: false),
                    Commentator = table.Column<string>(maxLength: 50, nullable: true),
                    Commenter = table.Column<string>(nullable: false),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    PostID = table.Column<string>(maxLength: 100, nullable: false),
                    ParrentID = table.Column<string>(maxLength: 100, nullable: true),
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
                name: "PostImages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<string>(maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PostImages_Posts_PostID",
                        column: x => x.PostID,
                        principalTable: "Posts",
                        principalColumn: "PostID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostID = table.Column<string>(maxLength: 100, nullable: false),
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
                    { 1, "News", new DateTime(2020, 8, 22, 15, 7, 43, 321, DateTimeKind.Local).AddTicks(9162) },
                    { 2, "Review", new DateTime(2020, 8, 22, 15, 7, 43, 323, DateTimeKind.Local).AddTicks(1552) },
                    { 3, "Project", new DateTime(2020, 8, 22, 15, 7, 43, 323, DateTimeKind.Local).AddTicks(1611) },
                    { 4, "Donate", new DateTime(2020, 8, 22, 15, 7, 43, 323, DateTimeKind.Local).AddTicks(1615) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"), "f2856084-6743-40c0-bff9-3158bef33c9a", "admin", "admin" },
                    { new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"), "7713a67b-c96c-4db1-8761-ec4e1fdc1b9b", "Writer", "Writer" }
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
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"), 0, null, "6b0269d4-4be3-4f55-89f0-dc8ec4cecde9", "hoangthuan2092003@gmail.com", true, false, null, "hoangthuan2092003@gmail.com", "admin", "AQAAAAEAACcQAAAAEIBWWcySZMjjeRKGgVxgpaoCp7DxBlwNlqP/4uXXeeepm6u/QFitbeqLUa4H0eLVhg==", null, false, "", false, "admin" },
                    { new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), 0, null, "6a1ad09a-844c-46a7-9de5-9e261930fc99", "hoangthuan2092003@gmail.com", true, false, null, "hoangthuan2092003@gmail.com", "hoho303", "AQAAAAEAACcQAAAAEJn3/2f0VGZYfn9LxaIOJ/vbMN52Cyoq7wTG97VpF616A4AbJQPQ1oN1R5kyq0M9Wg==", null, false, "", false, "hoho303" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryID", "CategoryID", "CategoryName", "CreateDate" },
                values: new object[,]
                {
                    { 1, 1, "Chaos;Head", new DateTime(2020, 8, 22, 15, 7, 43, 325, DateTimeKind.Local).AddTicks(94) },
                    { 2, 1, "Chaos;Child", new DateTime(2020, 8, 22, 15, 7, 43, 325, DateTimeKind.Local).AddTicks(1522) },
                    { 3, 1, "Steins;Gate", new DateTime(2020, 8, 22, 15, 7, 43, 325, DateTimeKind.Local).AddTicks(1558) },
                    { 4, 2, "Chaos;Child", new DateTime(2020, 8, 22, 15, 7, 43, 325, DateTimeKind.Local).AddTicks(1561) },
                    { 5, 3, "Chaos;Head", new DateTime(2020, 8, 22, 15, 7, 43, 325, DateTimeKind.Local).AddTicks(1563) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostID",
                table: "Comments",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostID",
                table: "PostImages",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_SubCategoryID",
                table: "Posts",
                column: "SubCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserID",
                table: "Posts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_PostID",
                table: "PostTags",
                column: "PostID");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryID",
                table: "SubCategories",
                column: "CategoryID");
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
                name: "PostImages");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
