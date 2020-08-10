using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class updatecomment1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Child1");

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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 16, 52, 26, 120, DateTimeKind.Local).AddTicks(1216));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 16, 52, 26, 121, DateTimeKind.Local).AddTicks(3175));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 16, 52, 26, 121, DateTimeKind.Local).AddTicks(3201));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 16, 52, 26, 121, DateTimeKind.Local).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Child2",
                columns: new[] { "CommentTime", "ParrentID", "UserID" },
                values: new object[] { new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(6075), "Chaos;Child1-1", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID" },
                values: new object[,]
                {
                    { "Chaos;Head1-1", new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(3958), "Đẹp trai vô danh", "Bài review rất hay", null, "Chaos;Head1" },
                    { "Chaos;Head1-2", new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(5358), "Đẹp trai có danh", "Ừ bài hay thật", "Chaos;Head1-1", "Chaos;Head1" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID", "UserID" },
                values: new object[] { "Chaos;Head1-3", new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(6062), null, "Cảm ơn các bạn", "Chaos;Head1-1", "Chaos;Head1", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID" },
                values: new object[] { "Chaos;Child1", new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(6072), "Bá đạo trên từng hạt gạo", "Bài review rất tệ", null, "Chaos;Child1" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Child1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 10, 16, 52, 26, 122, DateTimeKind.Local).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Head1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "23650c93-2ac7-4884-afb9-b626c4ac0185");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "0c1fe732-39bb-4f10-b326-38337ffbd3f8");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55c81996-b305-448a-8418-ad721c6b77a1", "AQAAAAEAACcQAAAAEBmIT2KPYEVnVbsoNHhz03QSe77rKtYo6DXBtYTCn7ud2fI4758Pic8ctcR1RUztgA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09f36f48-7d30-4760-ac76-caedcdc5df89", "AQAAAAEAACcQAAAAELmZTUTqreuM3LtfG/jfiCfnyxdnUvp4pdUSm9QTio5mAeaRr/jqMBMO6M/NYXpaTA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-1");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-2");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-3");

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

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Child2",
                columns: new[] { "CommentTime", "ParrentID", "UserID" },
                values: new object[] { new DateTime(2020, 8, 10, 15, 30, 32, 327, DateTimeKind.Local).AddTicks(4514), "Review Visual Novel Chaos;Child1", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

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
    }
}
