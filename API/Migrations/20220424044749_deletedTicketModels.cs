using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class deletedTicketModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppProjectAppUser");

            migrationBuilder.DropTable(
                name: "AppTicket");

            migrationBuilder.DropTable(
                name: "AppProject");

            migrationBuilder.DropTable(
                name: "Priority");

            migrationBuilder.DropTable(
                name: "AppMilestone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppMilestone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMilestone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MilestoneId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppProject_AppMilestone_MilestoneId",
                        column: x => x.MilestoneId,
                        principalTable: "AppMilestone",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AppProjectAppUser",
                columns: table => new
                {
                    AssignedProjectsId = table.Column<int>(type: "int", nullable: false),
                    AssignedUsersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppProjectAppUser", x => new { x.AssignedProjectsId, x.AssignedUsersId });
                    table.ForeignKey(
                        name: "FK_AppProjectAppUser_AppProject_AssignedProjectsId",
                        column: x => x.AssignedProjectsId,
                        principalTable: "AppProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppProjectAppUser_AspNetUsers_AssignedUsersId",
                        column: x => x.AssignedUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppTicket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignedUserId = table.Column<int>(type: "int", nullable: true),
                    PriorityId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    AppRoleId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppTicket_AppProject_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "AppProject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppTicket_AspNetRoles_AppRoleId",
                        column: x => x.AppRoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppTicket_AspNetUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AppTicket_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalTable: "Priority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppProject_MilestoneId",
                table: "AppProject",
                column: "MilestoneId");

            migrationBuilder.CreateIndex(
                name: "IX_AppProjectAppUser_AssignedUsersId",
                table: "AppProjectAppUser",
                column: "AssignedUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTicket_AppRoleId",
                table: "AppTicket",
                column: "AppRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTicket_AssignedUserId",
                table: "AppTicket",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTicket_PriorityId",
                table: "AppTicket",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_AppTicket_ProjectId",
                table: "AppTicket",
                column: "ProjectId");
        }
    }
}
