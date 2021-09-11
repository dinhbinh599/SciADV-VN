using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class addsubcommentcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsView",
                table: "SubComments",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsView",
                table: "SubComments");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 10, DateTimeKind.Local).AddTicks(162));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 11, DateTimeKind.Local).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 11, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 11, DateTimeKind.Local).AddTicks(3569));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "2d2494ff-be4e-4451-9f2c-8f55fa879fa7");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "924b6989-c6fc-4b35-a7f1-83ef80ec073b");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 13, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 13, DateTimeKind.Local).AddTicks(2684));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 13, DateTimeKind.Local).AddTicks(2721));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 13, DateTimeKind.Local).AddTicks(2724));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 9, 6, 18, 55, 42, 13, DateTimeKind.Local).AddTicks(2726));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d91a5a1b-7e00-4664-9a00-1d69cbfdd353", "AQAAAAEAACcQAAAAEFsPa6Y8aFzYrGG8fneTzANFVdzDXDAGw4jnSTwLGCw+gKHsshN20IQ4Hh8EaIRv9w==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1844fcb0-8655-4622-8242-f1987b867e8a", "AQAAAAEAACcQAAAAEM5P6vtFEMh+mFvaS1hzPeIuCne15wBApzudCKEMPxxlXGor04Y0eerLx/dcyyde8A==" });
        }
    }
}
