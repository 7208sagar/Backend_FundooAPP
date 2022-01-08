using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class CN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Remainder",
                table: "NotessssTables",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "CollaboratorT",
                columns: table => new
                {
                    CollaboratorId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotesId = table.Column<long>(nullable: false),
                    SenderEmail = table.Column<string>(nullable: false),
                    ReceiverEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollaboratorT", x => x.CollaboratorId);
                    table.ForeignKey(
                        name: "FK_CollaboratorT_NotessssTables_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NotessssTables",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollaboratorT_NotesId",
                table: "CollaboratorT",
                column: "NotesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollaboratorT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Remainder",
                table: "NotessssTables",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
