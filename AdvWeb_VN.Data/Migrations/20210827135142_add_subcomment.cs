using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdvWeb_VN.Data.Migrations
{
    public partial class add_subcomment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManage",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Comments");

            migrationBuilder.AddColumn<bool>(
                name: "IsManaged",
                table: "Comments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SubComments",
                columns: table => new
                {
                    SubCommentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Commentator = table.Column<string>(maxLength: 50, nullable: true),
                    Commenter = table.Column<string>(nullable: false),
                    CommentTime = table.Column<DateTime>(nullable: false),
                    PostID = table.Column<int>(nullable: false),
                    IsManaged = table.Column<bool>(nullable: false, defaultValue: false),
                    CommentID = table.Column<int>(nullable: false),
                    LikeCount = table.Column<int>(nullable: false, defaultValue: 0),
                    DislikeCount = table.Column<int>(nullable: false, defaultValue: 0),
                    UserID = table.Column<Guid>(nullable: false, defaultValue: new Guid("00000000-0000-0000-0000-000000000000"))
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

            migrationBuilder.CreateIndex(
                name: "IX_SubComments_CommentID",
                table: "SubComments",
                column: "CommentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubComments");

            migrationBuilder.DropColumn(
                name: "IsManaged",
                table: "Comments");

            migrationBuilder.AddColumn<bool>(
                name: "IsManage",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Comments",
                type: "int",
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
    }
}
