using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class L4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.CreateTable(
                name: "LabelT",
                columns: table => new
                {
                    LableId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotesId = table.Column<long>(nullable: false),
                    Id = table.Column<long>(nullable: false),
                    UserId = table.Column<long>(nullable: true),
                    Labels = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabelT", x => x.LableId);
                    table.ForeignKey(
                        name: "FK_LabelT_NotessssTables_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NotessssTables",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabelT_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabelT_NotesId",
                table: "LabelT",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_LabelT_UserId",
                table: "LabelT",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabelT");

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    LableId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Labels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotesId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.LableId);
                    table.ForeignKey(
                        name: "FK_Label_NotessssTables_NotesId",
                        column: x => x.NotesId,
                        principalTable: "NotessssTables",
                        principalColumn: "NotesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Label_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Label_NotesId",
                table: "Label",
                column: "NotesId");

            migrationBuilder.CreateIndex(
                name: "IX_Label_UserId",
                table: "Label",
                column: "UserId");
        }
    }
}
