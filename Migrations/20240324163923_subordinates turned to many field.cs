using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eapproval.Migrations
{
    /// <inheritdoc />
    public partial class subordinatesturnedtomanyfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subordinates");

            migrationBuilder.CreateTable(
                name: "TeamSuboridinates",
                columns: table => new
                {
                    SubordinatesId = table.Column<int>(type: "int", nullable: false),
                    TeamMembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamSuboridinates", x => new { x.SubordinatesId, x.TeamMembersId });
                    table.ForeignKey(
                        name: "FK_TeamSuboridinates_Teams_TeamMembersId",
                        column: x => x.TeamMembersId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeamSuboridinates_Users_SubordinatesId",
                        column: x => x.SubordinatesId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeamSuboridinates_TeamMembersId",
                table: "TeamSuboridinates",
                column: "TeamMembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeamSuboridinates");

            migrationBuilder.CreateTable(
                name: "Subordinates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Rank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subordinates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subordinates_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subordinates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subordinates_TeamId",
                table: "Subordinates",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Subordinates_UserId",
                table: "Subordinates",
                column: "UserId");
        }
    }
}
