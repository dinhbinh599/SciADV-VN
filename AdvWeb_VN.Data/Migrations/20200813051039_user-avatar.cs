using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class useravatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "Posts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsDefault",
                table: "PostImages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 203, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 204, DateTimeKind.Local).AddTicks(5802));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 204, DateTimeKind.Local).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 204, DateTimeKind.Local).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1-1",
                column: "CommentTime",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 208, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Child1-2",
                columns: new[] { "CommentTime", "UserID" },
                values: new object[] { new DateTime(2020, 8, 13, 12, 10, 38, 208, DateTimeKind.Local).AddTicks(577), new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-1",
                column: "CommentTime",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 207, DateTimeKind.Local).AddTicks(7443));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-2",
                column: "CommentTime",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 207, DateTimeKind.Local).AddTicks(9600));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentID",
                keyValue: "Chaos;Head1-3",
                columns: new[] { "CommentTime", "UserID" },
                values: new object[] { new DateTime(2020, 8, 13, 12, 10, 38, 208, DateTimeKind.Local).AddTicks(563), new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14") });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Child1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 206, DateTimeKind.Local).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostID",
                keyValue: "Chaos;Head1",
                column: "WriteTime",
                value: new DateTime(2020, 8, 13, 12, 10, 38, 207, DateTimeKind.Local).AddTicks(1740));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "0c7e34af-ee56-4160-8ac4-efe39ca6d149");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "5dfab554-d03a-4c1c-929b-ac26623fcfbc");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5c9ce0fa-aa73-4792-a0d8-b61179d53a3b", "AQAAAAEAACcQAAAAEM9KOV7pE4QnB7eEGHg0n8uRX2likjeclE9ZEaYhbkPE4AoL7zJUBuqRC2ZdED1vbQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7dba8790-27d7-4e3b-9d6c-b29049708a1a", "AQAAAAEAACcQAAAAEBH4s8CG6FAGfFvKi8KbW7I+rRqk7uA0uQEp4iXJ6S6MfcOu9T8ahKnnV+FNYh+ekg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "PostImages");

            migrationBuilder.AlterColumn<string>(
                name: "Thumbnail",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
        }
    }
}
