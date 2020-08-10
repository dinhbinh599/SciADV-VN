using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class updatecomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "hoho1");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "hoho2");

            migrationBuilder.AddColumn<string>(
                name: "ParrentID",
                table: "Comments",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 15, 30, 32, 323, DateTimeKind.Local).AddTicks(6427));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 15, 30, 32, 324, DateTimeKind.Local).AddTicks(7387));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 15, 30, 32, 324, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 15, 30, 32, 324, DateTimeKind.Local).AddTicks(7417));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID" },
                values: new object[,]
                {
                    { "Review Visual Novel Chaos;Head1", new DateTime(2020, 8, 10, 15, 30, 32, 327, DateTimeKind.Local).AddTicks(2552), "Đẹp trai vô danh", "Bài review rất hay", null, "Chaos;Head1" },
                    { "Review Visual Novel Chaos;Head2", new DateTime(2020, 8, 10, 15, 30, 32, 327, DateTimeKind.Local).AddTicks(3946), "Đẹp trai có danh", "Ừ bài hay thật", "Review Visual Novel Chaos;Head1", "Chaos;Head1" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID", "UserID" },
                values: new object[] { "Review Visual Novel Chaos;Head3", new DateTime(2020, 8, 10, 15, 30, 32, 327, DateTimeKind.Local).AddTicks(4502), null, "Cảm ơn các bạn", "Review Visual Novel Chaos;Head1", "Chaos;Head1", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID" },
                values: new object[] { "Review Visual Novel Chaos;Child1", new DateTime(2020, 8, 10, 15, 30, 32, 327, DateTimeKind.Local).AddTicks(4511), "Bá đạo trên từng hạt gạo", "Bài review rất tệ", null, "Chaos;Child1" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID", "UserID" },
                values: new object[] { "Review Visual Novel Chaos;Child2", new DateTime(2020, 8, 10, 15, 30, 32, 327, DateTimeKind.Local).AddTicks(4514), null, "Xin lỗi, mình sẽ cố gắng cải thiện!", "Review Visual Novel Chaos;Child1", "Chaos;Child1", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Child1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 10, 15, 30, 32, 326, DateTimeKind.Local).AddTicks(6400));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Head1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 10, 15, 30, 32, 326, DateTimeKind.Local).AddTicks(8955));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "c9c54646-b390-40c7-991e-9a920a82691b");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "62e687f9-b9dc-45df-8195-cf902ac40cc2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "087978e5-ca80-4fd4-a493-5f4c17d3f912", "AQAAAAEAACcQAAAAEF6HCmAsmp/M3o/iruDGrijd1P/en99Alu6HbKcgEde8CG7sLe/t4dholZZr0bu/rg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ec7c9df3-ea5a-4b66-a84d-ffdafee4ca3c", "AQAAAAEAACcQAAAAEH+MbRU8rYXKm2vVoQAgd7yLi0Apsc5Ho0CwCtVY/RaYgB/RY1Ub9K3kxcIwpqqLXw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Child1");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Child2");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Head1");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Head2");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Head3");

            migrationBuilder.DropColumn(
                name: "ParrentID",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 8, 6, 14, 53, 22, 161, DateTimeKind.Local).AddTicks(8301));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2020, 8, 6, 14, 53, 22, 162, DateTimeKind.Local).AddTicks(8485));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2020, 8, 6, 14, 53, 22, 162, DateTimeKind.Local).AddTicks(8510));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2020, 8, 6, 14, 53, 22, 162, DateTimeKind.Local).AddTicks(8514));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "PostID" },
                values: new object[,]
                {
                    { "hoho1", new DateTime(2020, 8, 6, 14, 53, 22, 164, DateTimeKind.Local).AddTicks(8764), "Đẹp trai vô danh", "Bài review rất hay", "Chaos;Head1" },
                    { "hoho2", new DateTime(2020, 8, 6, 14, 53, 22, 164, DateTimeKind.Local).AddTicks(9756), "Bá đạo trên từng hạt gạo", "Bài review rất tệ", "Chaos;Child1" }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Child1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 6, 14, 53, 22, 164, DateTimeKind.Local).AddTicks(2869));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Head1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 6, 14, 53, 22, 164, DateTimeKind.Local).AddTicks(5235));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "0312de49-7acb-495e-97fb-d56e5ae0afb4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "f0098992-d4e5-40d4-85bc-a033a18be13a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "328d7c38-3bbe-4e24-a8e8-bc796fe9fddb", "AQAAAAEAACcQAAAAEGfqwSyKDVuZUcIU6uujMLvmllAyWpHSaSCflVBEMXg3ynCFIPL3eRADDx0UzuhWBA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e5faefa-79e2-4fc5-a9f8-7e9d19f49e75", "AQAAAAEAACcQAAAAEPrCyqTFJow+D01r/232kJqUVISKqGGDkOorfh2meJRO5PUBOnPw1O4uCA3zNuIBGQ==" });
        }
    }
}
