using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class ProjectContextPart2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Projects_AppProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AppProjectId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppProjectId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Bugs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppProjectAppUser",
                columns: table => new
                {
                    AssignedProjectsId = table.Column<int>(type: "INTEGER", nullable: false),
                    AssignedUsersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProjectAppUser", x => new { x.AssignedProjectsId, x.AssignedUsersId });
                    table.ForeignKey(
                        name: "FK_AppProjectAppUser_AspNetUsers_AssignedUsersId",
                        column: x => x.AssignedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppProjectAppUser_Projects_AssignedProjectsId",
                        column: x => x.AssignedProjectsId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugs_AppUserId",
                table: "Bugs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectAppUser_AssignedUsersId",
                table: "AppProjectAppUser",
                column: "AssignedUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugs_AspNetUsers_AppUserId",
                table: "Bugs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugs_AspNetUsers_AppUserId",
                table: "Bugs");

            migrationBuilder.DropTable(
                name: "AppProjectAppUser");

            migrationBuilder.DropIndex(
                name: "IX_Bugs_AppUserId",
                table: "Bugs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Bugs");

            migrationBuilder.AddColumn<int>(
                name: "AppProjectId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AppProjectId",
                table: "AspNetUsers",
                column: "AppProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Projects_AppProjectId",
                table: "AspNetUsers",
                column: "AppProjectId",
                principalTable: "Projects",
                principalColumn: "Id");
        }
    }
}
