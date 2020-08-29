using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class add : Migration
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
                    { 1, "News", new DateTime(2020, 8, 25, 15, 22, 7, 862, DateTimeKind.Local).AddTicks(8489) },
                    { 2, "Review", new DateTime(2020, 8, 25, 15, 22, 7, 864, DateTimeKind.Local).AddTicks(617) },
                    { 3, "Project", new DateTime(2020, 8, 25, 15, 22, 7, 864, DateTimeKind.Local).AddTicks(650) },
                    { 4, "Donate", new DateTime(2020, 8, 25, 15, 22, 7, 864, DateTimeKind.Local).AddTicks(654) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"), "bae8194c-7e85-445c-9964-3e9115aac2f4", "admin", "admin" },
                    { new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"), "5418defd-e23d-446b-9c55-d2b3555d0ad4", "Writer", "Writer" }
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
                    { new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"), 0, null, "8355d864-e204-4215-b9ee-f7d2f947d438", "hoangthuan2092003@gmail.com", true, false, null, "hoangthuan2092003@gmail.com", "admin", "AQAAAAEAACcQAAAAEOlLh8HxImfunDzO6jCTKsad8dzECelHNN5Dt4es0Fdny0J/bwXLyXd7JRerL8nX8A==", null, false, "", false, "admin" },
                    { new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"), 0, null, "1597057c-61ce-4e54-83a3-6588e6b80366", "hoangthuan2092003@gmail.com", true, false, null, "hoangthuan2092003@gmail.com", "hoho303", "AQAAAAEAACcQAAAAEDLMAgLxjfBESXAYj+QvPsoN94WkKA9ib9Fj5tciKLyujQlViSpeNhbfsViZfZPKFA==", null, false, "", false, "hoho303" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryID", "CategoryID", "CategoryName", "CreateDate" },
                values: new object[,]
                {
                    { 1, 1, "Chaos;Head", new DateTime(2020, 8, 25, 15, 22, 7, 865, DateTimeKind.Local).AddTicks(9771) },
                    { 2, 1, "Chaos;Child", new DateTime(2020, 8, 25, 15, 22, 7, 866, DateTimeKind.Local).AddTicks(1212) },
                    { 3, 1, "Steins;Gate", new DateTime(2020, 8, 25, 15, 22, 7, 866, DateTimeKind.Local).AddTicks(1254) },
                    { 4, 2, "Chaos;Child", new DateTime(2020, 8, 25, 15, 22, 7, 866, DateTimeKind.Local).AddTicks(1257) },
                    { 5, 3, "Chaos;Head", new DateTime(2020, 8, 25, 15, 22, 7, 866, DateTimeKind.Local).AddTicks(1259) }
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
        }
    }
}
