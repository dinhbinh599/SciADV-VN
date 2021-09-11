using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class fixcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 636, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 637, DateTimeKind.Local).AddTicks(2903));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 637, DateTimeKind.Local).AddTicks(2933));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 637, DateTimeKind.Local).AddTicks(2936));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "711a563e-a448-422d-a20d-014275be1646");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "4bb98392-87c6-4e40-bfe7-1ca45cf05c4f");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 639, DateTimeKind.Local).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 639, DateTimeKind.Local).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 639, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 639, DateTimeKind.Local).AddTicks(1695));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 9, 9, 21, 47, 3, 639, DateTimeKind.Local).AddTicks(1697));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2c022c7c-a4d3-4f88-a5cc-f7afb24000de", "AQAAAAEAACcQAAAAEHLJVpp/PTbaCQ00JEkOFx21VFeyT4Ync0GtcArJFRq1Ir+qI1E8ifs1o8Cp4OZ11Q==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "75ba0b81-4b69-47f9-b05f-d44a3674c71b", "AQAAAAEAACcQAAAAEGpLpcUvSgI3S8bz9kSa5/kMlO4rpDaQJKkqa1fsY98cjWXsQbpWIWrVS20jd5PA0g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 69, DateTimeKind.Local).AddTicks(983));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 70, DateTimeKind.Local).AddTicks(854));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 70, DateTimeKind.Local).AddTicks(896));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 70, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "445eaca3-5fa8-4d96-8067-1ccefff19f90");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "d4575d64-a393-4c3c-b9b3-5444374b822e");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 71, DateTimeKind.Local).AddTicks(8887));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 72, DateTimeKind.Local).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 72, DateTimeKind.Local).AddTicks(295));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 72, DateTimeKind.Local).AddTicks(297));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 21, 55, 55, 72, DateTimeKind.Local).AddTicks(300));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "06471269-89f0-4795-ba81-5b75c57faa31", "AQAAAAEAACcQAAAAEAEtjtCoA0IZ2mOgrnkzDuaVnIvgve0wCksXd0w/zsOzdRkdUIfTrNVFRAYTv1XjFw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "bb4e27a4-5ceb-43d2-a27d-e36e9f330ba3", "AQAAAAEAACcQAAAAEBca2Fqn+qYCswnGVriugZztXS6hqwogcgsLr+jIjcrw/f5IGBCpZjTsKajvEPYgVw==" });
        }
    }
}
