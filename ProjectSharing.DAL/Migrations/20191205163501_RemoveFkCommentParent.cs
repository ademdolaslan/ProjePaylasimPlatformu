using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectSharing.DAL.Migrations
{
    public partial class RemoveFkCommentParent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_CommentParentID",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_CommentParentID",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Comments_CommentParentID",
                table: "Comments",
                column: "CommentParentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_CommentParentID",
                table: "Comments",
                column: "CommentParentID",
                principalTable: "Comments",
                principalColumn: "CommentID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
