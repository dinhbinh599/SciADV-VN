using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class deletesubcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubComments");

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
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1afd1efb-deba-4d1c-88e9-b178493b4298", "AQAAAAEAACcQAAAAEOxm/DwM6RdLz5CummxeZEkyzhzZ5UYZAawQxQbahL5hakmb9w7lH32rW/hSvdfNjQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubComments",
                columns: table => new
                {
                    SubCommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentID = table.Column<int>(type: "int", nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Commentator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Commenter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DislikeCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsManaged = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsView = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    LikeCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    PostID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubComments", x => x.SubCommentID);
                    table.ForeignKey(
                        name: "FK_SubComments_Comments_CommentID",
                        column: x => x.CommentID,
                        principalTable: "Comments",
                        principalColumn: "CommentID",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_CommentID",
                table: "SubComments",
                column: "CommentID");
        }
    }
}
