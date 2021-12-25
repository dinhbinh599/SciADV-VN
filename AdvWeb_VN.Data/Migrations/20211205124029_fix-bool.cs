using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class fixbool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 641, DateTimeKind.Local).AddTicks(1934));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 642, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 642, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 642, DateTimeKind.Local).AddTicks(2049));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "45239fe7-ac57-4e69-b49c-5faff90e073c");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "64c2b8ba-2a6e-4e7a-9ce0-d3d938563a21");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 643, DateTimeKind.Local).AddTicks(9584));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 644, DateTimeKind.Local).AddTicks(940));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 644, DateTimeKind.Local).AddTicks(975));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 644, DateTimeKind.Local).AddTicks(978));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 12, 5, 18, 19, 41, 644, DateTimeKind.Local).AddTicks(980));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "74257c37-87d5-4c11-b266-2133f25a66ca", "AQAAAAEAACcQAAAAEHl6WBXjbfUaZwtHjBTV0dn8/MWBSxTTSn455IDOPz0kksySb9UYA8Z9kgWcFX1kVw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "60a4b0f7-b58c-4f8b-8406-9674947aee27", "AQAAAAEAACcQAAAAEM91I+nFvoXdWK1n2o6e/wKM42h38FOUUVE0KgGwJkgPARts7LGmSmA5qL7WBjZclw==" });
        }
    }
}
