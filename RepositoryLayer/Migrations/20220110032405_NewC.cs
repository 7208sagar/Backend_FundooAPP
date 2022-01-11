using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class NewC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReceiverEmail",
                table: "CollaboratorT");

            migrationBuilder.DropColumn(
                name: "SenderEmail",
                table: "CollaboratorT");

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "CollaboratorT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "CollaboratorT",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "CollaboratorT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorT_UserId",
                table: "CollaboratorT",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollaboratorT_Users_UserId",
                table: "CollaboratorT",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollaboratorT_Users_UserId",
                table: "CollaboratorT");

            migrationBuilder.DropIndex(
                name: "IX_CollaboratorT_UserId",
                table: "CollaboratorT");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "CollaboratorT");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CollaboratorT");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CollaboratorT");

            migrationBuilder.AddColumn<string>(
                name: "ReceiverEmail",
                table: "CollaboratorT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SenderEmail",
                table: "CollaboratorT",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
