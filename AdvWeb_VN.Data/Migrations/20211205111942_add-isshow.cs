using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class addisshow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsShow",
                table: "SubCategories",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShow",
                table: "Posts",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsShow",
                table: "Categories",
                nullable: false,
                defaultValue: true);

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
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "60a4b0f7-b58c-4f8b-8406-9674947aee27", "nguyenhoangthuan2092003@gmail.com", "AQAAAAEAACcQAAAAEM91I+nFvoXdWK1n2o6e/wKM42h38FOUUVE0KgGwJkgPARts7LGmSmA5qL7WBjZclw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsShow",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "IsShow",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "IsShow",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 191, DateTimeKind.Local).AddTicks(6789));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 192, DateTimeKind.Local).AddTicks(7624));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 192, DateTimeKind.Local).AddTicks(7655));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 192, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "3f10bd0c-295b-4248-a214-caf8c919e302");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "dc00ca1d-9dd8-4934-a087-9367caa8c272");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 194, DateTimeKind.Local).AddTicks(4642));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 194, DateTimeKind.Local).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 194, DateTimeKind.Local).AddTicks(6053));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 194, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 9, 11, 17, 18, 9, 194, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fe080476-4135-4e3e-9450-375a14f5c8f5", "AQAAAAEAACcQAAAAEDSnQuODWIEqxQwMRoJmVrI3xxFQNkxyApemIazQ9wSqdWK3i0xv8lWwG5X5rDgBMw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "PasswordHash" },
                values: new object[] { "1afd1efb-deba-4d1c-88e9-b178493b4298", "hoangthuan2092003@gmail.com", "AQAAAAEAACcQAAAAEOxm/DwM6RdLz5CummxeZEkyzhzZ5UYZAawQxQbahL5hakmb9w7lH32rW/hSvdfNjQ==" });
        }
    }
}
