using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class ProjectPart4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_AppUserId",
                table: "Bugs");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_AppUserId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Bugs");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Bugs",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AppTicketAppUser",
                columns: table => new
                {
                    AssignedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    TicketsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTicketAppUser", x => new { x.AssignedUserId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_AppTicketAppUser_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppTicketAppUser_Bugs_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Bugs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppTicketAppUser_TicketsId",
                table: "AppTicketAppUser",
                column: "TicketsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppTicketAppUser");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Bugs");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Bugs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Bugs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_AppUserId",
                table: "Bugs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_AppUserId",
                table: "Bugs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
