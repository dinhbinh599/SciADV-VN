using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class add_like_dislike_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubComments");

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
                value: new DateTime(2021, 8, 27, 11, 16, 40, 521, DateTimeKind.Local).AddTicks(32));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 11, 16, 40, 522, DateTimeKind.Local).AddTicks(1116));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 11, 16, 40, 522, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 11, 16, 40, 522, DateTimeKind.Local).AddTicks(1150));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "e931c703-080b-451a-bb6d-c321ea204b8f");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "dea46147-36d5-4357-9e48-ea2e834ed0d9");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 11, 16, 40, 523, DateTimeKind.Local).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 11, 16, 40, 524, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 11, 16, 40, 524, DateTimeKind.Local).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 11, 16, 40, 524, DateTimeKind.Local).AddTicks(1469));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 11, 16, 40, 524, DateTimeKind.Local).AddTicks(1471));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0abe10fd-b626-41aa-a84c-6a066a10c99b", "AQAAAAEAACcQAAAAEP3fyYivxWHxMMMCCDELJxjEFpdqMNEVcCNx75NOqajBdhJKUTLb4M3cXK+oFX+6xw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81f40433-1fce-4c2b-8190-09c18c6627e3", "AQAAAAEAACcQAAAAEMuyErCfrCnV6ecEgsnB4quJ20hAIi8ReUokmpRFVUpynKU/beB2YyuDuQRvBRR/rg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Comments");

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
                    IsManage = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
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
                value: new DateTime(2021, 8, 27, 10, 46, 57, 231, DateTimeKind.Local).AddTicks(2947));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 10, 46, 57, 232, DateTimeKind.Local).AddTicks(3354));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 10, 46, 57, 232, DateTimeKind.Local).AddTicks(3392));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 10, 46, 57, 232, DateTimeKind.Local).AddTicks(3395));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("706a7f4f-a6ed-4e24-bd09-df7829865142"),
                column: "ConcurrencyStamp",
                value: "4297221b-ab88-4ac1-a6bf-0f7d585054b1");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("d00409db-a6ed-4985-a3b7-4036774572cd"),
                column: "ConcurrencyStamp",
                value: "c53ad04e-1c77-4c14-9fb0-6870518b9239");

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 10, 46, 57, 234, DateTimeKind.Local).AddTicks(1602));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 10, 46, 57, 234, DateTimeKind.Local).AddTicks(2976));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 3,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 10, 46, 57, 234, DateTimeKind.Local).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 4,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 10, 46, 57, 234, DateTimeKind.Local).AddTicks(3014));

            migrationBuilder.UpdateData(
                table: "SubCategories",
                keyColumn: "SubCategoryID",
                keyValue: 5,
                column: "CreateDate",
                value: new DateTime(2021, 8, 27, 10, 46, 57, 234, DateTimeKind.Local).AddTicks(3017));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0cfe64bd-645b-4f5a-91d1-c3082c132ed8"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "07ed5de2-25a0-44c4-8b58-4dd42821a7b3", "AQAAAAEAACcQAAAAEMZKLwAM3UttU7HY2/LTIWBMqra5n/7a2lhx2eQxNLtrWM754mHE/5D5PBoKnC45Zw==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5581e8dc-2614-4392-a95c-2e9411bfdb14"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3efc4c83-f993-4bc3-8fe0-9ee496f81369", "AQAAAAEAACcQAAAAEILM0Y9pn7mDljlNpROLCWtx6Rnu/E3qfFKkCBq9FKX2R8pEEE7PH234duBqVj2M2A==" });

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_CommentID",
                table: "SubComments",
                column: "CommentID");
        }
    }
}
