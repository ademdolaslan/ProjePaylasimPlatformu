using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSharing.DAL.Migrations
{
    public partial class FilesTableAddUserIdColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserID",
                table: "Files",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_UserID",
                table: "Files",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_Users_UserID",
                table: "Files",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_Users_UserID",
                table: "Files");

            migrationBuilder.DropIndex(
                name: "IX_Files_UserID",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Files");
        }
    }
}
