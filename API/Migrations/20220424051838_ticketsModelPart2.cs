using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class ticketsModelPart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTicket_AspNetUsers_UserId",
                table: "AppTicket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppTicket",
                table: "AppTicket");

            migrationBuilder.RenameTable(
                name: "AppTicket",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_AppTicket_UserId",
                table: "Tickets",
                newName: "IX_Tickets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_UserId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "AppTicket");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_UserId",
                table: "AppTicket",
                newName: "IX_AppTicket_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppTicket",
                table: "AppTicket",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTicket_AspNetUsers_UserId",
                table: "AppTicket",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
