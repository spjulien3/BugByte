using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    public partial class addTicketPart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priority_PriorityId",
                table: "Tickets");

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Tickets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "Id", "Description" },
                values: new object[] { 1, "Low" });

            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "Id", "Description" },
                values: new object[] { 2, "Medium" });

            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "Id", "Description" },
                values: new object[] { 3, "High" });

            migrationBuilder.InsertData(
                table: "Priority",
                columns: new[] { "Id", "Description" },
                values: new object[] { 4, "Critical" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priority_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Priority_PriorityId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "Priority",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Priority",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Priority",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Priority",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<int>(
                name: "PriorityId",
                table: "Tickets",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Priority_PriorityId",
                table: "Tickets",
                column: "PriorityId",
                principalTable: "Priority",
                principalColumn: "Id");
        }
    }
}
