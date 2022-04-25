using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class addMilestonesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MilestoneId",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Milestones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Milestones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_MilestoneId",
                table: "Projects",
                column: "MilestoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Milestones_MilestoneId",
                table: "Projects",
                column: "MilestoneId",
                principalTable: "Milestones",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Milestones_MilestoneId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Milestones");

            migrationBuilder.DropIndex(
                name: "IX_Projects_MilestoneId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "MilestoneId",
                table: "Projects");
        }
    }
}
