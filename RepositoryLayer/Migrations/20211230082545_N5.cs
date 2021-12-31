using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class N5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "NotessssTables",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotessssTables_UserId",
                table: "NotessssTables",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NotessssTables_Users_UserId",
                table: "NotessssTables",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NotessssTables_Users_UserId",
                table: "NotessssTables");

            migrationBuilder.DropIndex(
                name: "IX_NotessssTables_UserId",
                table: "NotessssTables");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NotessssTables");
        }
    }
}
