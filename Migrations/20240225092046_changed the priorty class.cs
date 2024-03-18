using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eapproval.Migrations
{
    /// <inheritdoc />
    public partial class changedthepriortyclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PriorityClass_InitialPriorityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_PriorityClass_PriorityId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PriorityClass",
                table: "PriorityClass");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "PriorityClass");

            migrationBuilder.RenameTable(
                name: "PriorityClass",
                newName: "Priorities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Priorities",
                table: "Priorities",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priorities_InitialPriorityId",
                table: "Tickets",
                column: "InitialPriorityId",
                principalTable: "Priorities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "Priorities",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priorities_InitialPriorityId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priorities_PriorityId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Priorities",
                table: "Priorities");

            migrationBuilder.RenameTable(
                name: "Priorities",
                newName: "PriorityClass");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "PriorityClass",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PriorityClass",
                table: "PriorityClass",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PriorityClass_InitialPriorityId",
                table: "Tickets",
                column: "InitialPriorityId",
                principalTable: "PriorityClass",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_PriorityClass_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "PriorityClass",
                principalColumn: "Id");
        }
    }
}
