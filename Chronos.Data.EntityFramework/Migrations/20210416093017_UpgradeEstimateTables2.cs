using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Data.EntityFramework.Migrations
{
    public partial class UpgradeEstimateTables2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EstimateItemTasks_Name_Discipline_EstimateItemId",
                table: "EstimateItemTasks");

            migrationBuilder.DropColumn(
                name: "Discipline",
                table: "EstimateItemTasks");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EstimateItemTasks",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Assumptions",
                table: "EstimateItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Discipline",
                table: "EstimateItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Assumptions",
                table: "EstimateItems");

            migrationBuilder.DropColumn(
                name: "Discipline",
                table: "EstimateItems");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "EstimateItemTasks",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Discipline",
                table: "EstimateItemTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EstimateItemTasks_Name_Discipline_EstimateItemId",
                table: "EstimateItemTasks",
                columns: new[] { "Name", "Discipline", "EstimateItemId" },
                unique: true);
        }
    }
}
