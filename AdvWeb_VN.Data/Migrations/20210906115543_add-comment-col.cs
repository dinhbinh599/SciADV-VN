using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class addcommentcol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsView",
                table: "Comments",
                nullable: false,
                defaultValue: false);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsView",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 378, DateTimeKind.Local).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 379, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 379, DateTimeKind.Local).AddTicks(9535));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 379, DateTimeKind.Local).AddTicks(9538));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "281c603b-38aa-46b2-b931-b706ba722858");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "3c0ec2c7-b045-4608-8bd2-b71757ba1791");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 381, DateTimeKind.Local).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 381, DateTimeKind.Local).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 381, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 381, DateTimeKind.Local).AddTicks(6100));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 20, 51, 41, 381, DateTimeKind.Local).AddTicks(6102));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0639b3ab-072d-4fc7-9f88-af1411c3f9af", "AQAAAAEAACcQAAAAEHRfwvbRctM0RDWb+c1NYQkt6vYI+6PfwOl2MmtgIyLTfjUfyOdg5Kwvb2AtCVUtWw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e1f22fdc-0704-4779-b906-11aa6165a71a", "AQAAAAEAACcQAAAAEMhbNhqoifAXAwkTX0/1d9wNFI+SPrzI1RssADycal4W06YlMLRchwfwSdHaqDo0aA==" });
        }
    }
}
