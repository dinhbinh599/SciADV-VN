using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdvWeb_VN.Data.Migrations
{
    public partial class addsummarycolumntoposttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Posts",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2755));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2756));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "feedfa0a-b065-4378-9395-eca432576316");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "5c6a7c75-2ad9-4506-9e6e-49d2fae578b0");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2830));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2831));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2832));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2025, 3, 15, 12, 52, 57, 910, DateTimeKind.Local).AddTicks(2833));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "810d865a-6f13-48bc-8262-4260b3b08fb8", "AQAAAAEAACcQAAAAEGMN4HmK3hkCVePptiUN1osORWhTFt6JFECBcGakxfYB8OTqmRi0UH8kufeKv98Uqw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7c3dac48-b663-4d7c-b926-24725bf52ca9", "AQAAAAEAACcQAAAAEFplcJbWZlVrE5Hi0hb9doNBLDy+Ng6x6d7rK782UEHEoUlbNwjzwHAiu9UIACxuGQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 370, DateTimeKind.Local).AddTicks(3526));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 371, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 371, DateTimeKind.Local).AddTicks(5450));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 371, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "ec177e6a-098d-414b-853b-b416d69d6ff4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "0a935a83-b4f2-4f83-b110-3eb9c27ba296");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 373, DateTimeKind.Local).AddTicks(5313));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 373, DateTimeKind.Local).AddTicks(6706));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 373, DateTimeKind.Local).AddTicks(6743));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 373, DateTimeKind.Local).AddTicks(6746));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 19, 40, 28, 373, DateTimeKind.Local).AddTicks(6748));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a057a0d5-946a-4792-87c2-6aa66b018ff2", "AQAAAAEAACcQAAAAEEqwoTn2oCzCP4I+Ovnbom4SO6zbB8G4ntdlaWvbk9kCGLqybN/7tJbXknSnKAMzyQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "477e7007-d595-472f-80eb-4719685521aa", "AQAAAAEAACcQAAAAEFtBGY+j6FTQb162MaaztZ/vruzvQJLCEprqBSsV2a1Cpx0/1OujWxXtGFrUBKL0PA==" });
        }
    }
}
