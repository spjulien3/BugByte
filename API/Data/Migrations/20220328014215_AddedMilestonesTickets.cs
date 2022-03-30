using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class AddedMilestonesTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Milestones_AppMilestoneId",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_AppProjectId",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "AppTicketAppUser");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_AppProjectId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Projects_AppMilestoneId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AppProjectId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "AppMilestoneId",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Milestones_Id",
                table: "Projects",
                column: "Id",
                principalTable: "Milestones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_Id",
                table: "Tickets",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_Id",
                table: "Tickets",
                column: "Id",
                principalTable: "Projects",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Milestones_Id",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_Id",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_Id",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AppProjectId",
                table: "Tickets",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "AppMilestoneId",
                table: "Projects",
                type: "INTEGER",
                nullable: true);

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
                        name: "FK_AppTicketAppUser_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_AppProjectId",
                table: "Tickets",
                column: "AppProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AppMilestoneId",
                table: "Projects",
                column: "AppMilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTicketAppUser_TicketsId",
                table: "AppTicketAppUser",
                column: "TicketsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Milestones_AppMilestoneId",
                table: "Projects",
                column: "AppMilestoneId",
                principalTable: "Milestones",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_AppProjectId",
                table: "Tickets",
                column: "AppProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
