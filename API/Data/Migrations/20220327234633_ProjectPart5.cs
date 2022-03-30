using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class ProjectPart5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTicketAppUser_Bugs_TicketsId",
                table: "AppTicketAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_Projects_AppProjectId",
                table: "Bugs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bugs",
                table: "Bugs");

            migrationBuilder.RenameTable(
                name: "Bugs",
                newName: "Tickets");

            migrationBuilder.RenameIndex(
                name: "IX_Bugs_AppProjectId",
                table: "Tickets",
                newName: "IX_Tickets_AppProjectId");

            migrationBuilder.AddColumn<int>(
                name: "AppRoleId",
                table: "Tickets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AppRoleId",
                table: "Tickets",
                column: "AppRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTicketAppUser_Tickets_TicketsId",
                table: "AppTicketAppUser",
                column: "TicketsId",
                principalTable: "Tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetRoles_AppRoleId",
                table: "Tickets",
                column: "AppRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_AppProjectId",
                table: "Tickets",
                column: "AppProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppTicketAppUser_Tickets_TicketsId",
                table: "AppTicketAppUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetRoles_AppRoleId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_AppProjectId",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tickets",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AppRoleId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AppRoleId",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Tickets",
                newName: "Bugs");

            migrationBuilder.RenameIndex(
                name: "IX_Tickets_AppProjectId",
                table: "Bugs",
                newName: "IX_Bugs_AppProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bugs",
                table: "Bugs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppTicketAppUser_Bugs_TicketsId",
                table: "AppTicketAppUser",
                column: "TicketsId",
                principalTable: "Bugs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_Projects_AppProjectId",
                table: "Bugs",
                column: "AppProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
