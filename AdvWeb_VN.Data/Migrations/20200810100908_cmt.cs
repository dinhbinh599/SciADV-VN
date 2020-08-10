using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class cmt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Review Visual Novel Chaos;Child2");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 337, DateTimeKind.Local).AddTicks(2792));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 338, DateTimeKind.Local).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 338, DateTimeKind.Local).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 338, DateTimeKind.Local).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-1",
                column: "CommentTime",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-2",
                column: "CommentTime",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(5399));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-3",
                columns: new[] { "CommentTime", "Commentator", "UserID" },
                values: new object[] { new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(6082), "hoho303", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID" },
                values: new object[] { "Chaos;Child1-1", new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(6091), "Bá đạo trên từng hạt gạo", "Bài review rất tệ", null, "Chaos;Child1" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID", "UserID" },
                values: new object[] { "Chaos;Child1-2", new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(6094), "hoho303", "Xin lỗi, mình sẽ cố gắng cải thiện!", "Chaos;Child1-1", "Chaos;Child1", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Child1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 339, DateTimeKind.Local).AddTicks(7865));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Head1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(196));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "dd2065fc-183c-4998-a211-2d99e5bfbe7c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "aa56d57c-11d8-4558-9d64-4d19161a7d42");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cc023882-a69f-4d6c-b4f9-73ab62d9f091", "AQAAAAEAACcQAAAAEAoxu/jI+sIXmVbsxOqHPbS08GUPnvTdrpqOUsl5sbkGbPd6VgNM6OswUMu5v9w4tg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "434147f4-4b87-4601-bb28-b4fd239c4a33", "AQAAAAEAACcQAAAAEHqYTHq/ErtMHwKQdMgLyXMrMaQRHtQBSzubFFr/7RYgm2kLHVEC5FrMkB9ESM5X5Q==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1-1");

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1-2");

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
                keyValue: "Chaos;Head1-1",
                column: "CommentTime",
                value: new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(3958));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-2",
                column: "CommentTime",
                value: new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-3",
                columns: new[] { "CommentTime", "Commentator", "UserID" },
                values: new object[] { new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(6062), null, new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID" },
                values: new object[] { "Chaos;Child1", new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(6072), "Bá đạo trên từng hạt gạo", "Bài review rất tệ", null, "Chaos;Child1" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentID", "CommentTime", "Commentator", "Commenter", "ParrentID", "PostID", "UserID" },
                values: new object[] { "Review Visual Novel Chaos;Child2", new DateTime(2020, 8, 10, 16, 52, 26, 123, DateTimeKind.Local).AddTicks(6075), null, "Xin lỗi, mình sẽ cố gắng cải thiện!", "Chaos;Child1-1", "Chaos;Child1", new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

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
    }
}
