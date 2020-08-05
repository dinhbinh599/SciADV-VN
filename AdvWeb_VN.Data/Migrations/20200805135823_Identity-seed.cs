using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class Identityseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { "Tom1", "Chaos;Head", new DateTime(2020, 8, 5, 20, 58, 22, 682, DateTimeKind.Local).AddTicks(4644) },
                    { "Tom2", "Chaos;Child", new DateTime(2020, 8, 5, 20, 58, 22, 684, DateTimeKind.Local).AddTicks(1319) },
                    { "Tom3", "Steins;Gate", new DateTime(2020, 8, 5, 20, 58, 22, 684, DateTimeKind.Local).AddTicks(1353) },
                    { "Tom4", "Robotics;Notes", new DateTime(2020, 8, 5, 20, 58, 22, 684, DateTimeKind.Local).AddTicks(1356) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"), "19633fd3-b66f-4b47-ba9c-078a3f9f777f", "admin", "admin" },
                    { new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"), "94188c0a-56e0-4ab7-8052-ce00c6241d89", "Writer", "Writer" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "TagID", "TagName" },
                values: new object[,]
                {
                    { "kiki1", "Visual Novel" },
                    { "kiki2", "Chaos;Head" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"), 0, "015746f4-927c-46a4-8243-05e2f778c17e", "hoangthuan2092003@gmail.com", true, false, null, "hoangthuan2092003@gmail.com", "admin", "AQAAAAEAACcQAAAAEJon30keugd4YPgX6aDwoQ3q27YeKlF1aU16zGPja5tgbCyvQQyBqg3JZsFvp/nlVw==", null, false, "", false, "admin" },
                    { new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), 0, "3d5a0fb4-ba7e-4113-9c66-caf29eeda7cc", "hoangthuan2092003@gmail.com", true, false, null, "hoangthuan2092003@gmail.com", "hoho303", "AQAAAAEAACcQAAAAEDrIvmoCKu33p2/ZMif1QwybaVogq83wvLD+G296vNSslLn8m5fEGT4/3Ulsi8M7hg==", null, false, "", false, "hoho303" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "CategoryID", "Contents", "PostName", "Thumbnail", "UserID", "WriteTime" },
                values: new object[] { "Chaos;Child1", "Tom2", "Đây là 1 Visual Novel rất hay", "Review Visual Novel Chaos;Child", "https://images-na.ssl-images-amazon.com/images/I/91HUMu2XDYL._RI_.jpg", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), new DateTime(2020, 8, 5, 20, 58, 22, 685, DateTimeKind.Local).AddTicks(9448) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostID", "CategoryID", "Contents", "PostName", "Thumbnail", "UserID", "WriteTime" },
                values: new object[] { "Chaos;Head1", "Tom1", "Đây là 1 Visual Novel rất hay", "Review Visual Novel Chaos;Head", "https://upload.wikimedia.org/wikipedia/vi/3/34/Chaos_Head_game_cover.jpg", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), new DateTime(2020, 8, 5, 20, 58, 22, 686, DateTimeKind.Local).AddTicks(2950) });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "PostID" },
                values: new object[,]
                {
                    { "hoho2", new DateTime(2020, 8, 5, 20, 58, 22, 686, DateTimeKind.Local).AddTicks(9803), "Bá đạo trên từng hạt gạo", "Bài review rất tệ", "Chaos;Child1" },
                    { "hoho1", new DateTime(2020, 8, 5, 20, 58, 22, 686, DateTimeKind.Local).AddTicks(8331), "Đẹp trai vô danh", "Bài review rất hay", "Chaos;Head1" }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "TagID", "PostID" },
                values: new object[,]
                {
                    { "kiki1", "Chaos;Child1" },
                    { "kiki1", "Chaos;Head1" },
                    { "kiki2", "Chaos;Head1" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"), new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142") });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), new Guid("d00409db-a6ed-4985-a3b7-4036774572cd") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: "Tom3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: "Tom4");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "hoho1");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "hoho2");

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "TagID", "PostID" },
                keyValues: new object[] { "kiki1", "Chaos;Child1" });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "TagID", "PostID" },
                keyValues: new object[] { "kiki1", "Chaos;Head1" });

            migrationBuilder.DeleteData(
                table: "PostTags",
                keyColumns: new[] { "TagID", "PostID" },
                keyValues: new object[] { "kiki2", "Chaos;Head1" });

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"));

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Child1");

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Head1");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: "kiki1");

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: "kiki2");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: "Tom1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: "Tom2");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"));
        }
    }
}
