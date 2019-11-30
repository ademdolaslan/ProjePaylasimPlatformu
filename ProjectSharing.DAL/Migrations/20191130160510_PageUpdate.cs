using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSharing.DAL.Migrations
{
    public partial class PageUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Pages",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PageCategoryID",
                table: "Pages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PageDescription",
                table: "Pages",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true),
                    CategoryDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pages_PageCategoryID",
                table: "Pages",
                column: "PageCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Category_PageCategoryID",
                table: "Pages",
                column: "PageCategoryID",
                principalTable: "Category",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Category_PageCategoryID",
                table: "Pages");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Pages_PageCategoryID",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageCategoryID",
                table: "Pages");

            migrationBuilder.DropColumn(
                name: "PageDescription",
                table: "Pages");
        }
    }
}
