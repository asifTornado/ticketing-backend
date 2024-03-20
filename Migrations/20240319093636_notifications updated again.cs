using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eapproval.Migrations
{
    /// <inheritdoc />
    public partial class notificationsupdatedagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_UserId1",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserId1",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Notifications");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_FromId",
                table: "Notifications",
                column: "FromId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_FromId",
                table: "Notifications",
                column: "FromId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Users_FromId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_FromId",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Notifications",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId1",
                table: "Notifications",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Users_UserId1",
                table: "Notifications",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
