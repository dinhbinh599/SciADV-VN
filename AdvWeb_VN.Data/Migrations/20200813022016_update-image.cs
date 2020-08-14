using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class updateimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "Users",
                unicode: false,
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PostImages",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostID = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    ImagePath = table.Column<string>(maxLength: 200, nullable: false),
                    Caption = table.Column<string>(maxLength: 200, nullable: true),
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

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 504, DateTimeKind.Local).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 505, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 505, DateTimeKind.Local).AddTicks(7499));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 505, DateTimeKind.Local).AddTicks(7502));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1-1",
                column: "CommentTime",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1-2",
                columns: new[] { "CommentTime", "UserID" },
                values: new object[] { new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(4885), new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-1",
                column: "CommentTime",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(2817));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-2",
                column: "CommentTime",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(4273));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-3",
                columns: new[] { "CommentTime", "UserID" },
                values: new object[] { new DateTime(2020, 8, 13, 9, 20, 14, 512, DateTimeKind.Local).AddTicks(4873), new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Child1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 511, DateTimeKind.Local).AddTicks(5039));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Head1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 13, 9, 20, 14, 511, DateTimeKind.Local).AddTicks(7936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "4acd489b-bd02-479c-ac22-a582dc7c4919");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "36d4e31a-a5f7-4e90-9d56-c74e48c135a6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b1145d5-3e57-4ddc-9e3d-4b2c00420998", "AQAAAAEAACcQAAAAEJnqS+XqacLwik5HWzJEr1+JqGmmILREfTjOD4bUD+7dGt9w/O5sSUkT7cuhfwtqFw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "636d7aed-25bf-4190-9876-a53c19dd0da2", "AQAAAAEAACcQAAAAEK9P54ByPdBag4iFfFowJcV1vC1CyPai9MKTda8dJZ7j1byLqf8PUgRAIIpB+3SsnA==" });

            migrationBuilder.CreateIndex(
                name: "IX_PostImages_PostID",
                table: "PostImages",
                column: "PostID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostImages");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "Users");

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
                keyValue: "Chaos;Child1-1",
                column: "CommentTime",
                value: new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1-2",
                columns: new[] { "CommentTime", "UserID" },
                values: new object[] { new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(6094), new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

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
                columns: new[] { "CommentTime", "UserID" },
                values: new object[] { new DateTime(2020, 8, 10, 17, 9, 7, 340, DateTimeKind.Local).AddTicks(6082), new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

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
    }
}
