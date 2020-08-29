using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class addcolcateID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"));

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"));

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "TagID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Posts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Posts");

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
        }
    }
}
