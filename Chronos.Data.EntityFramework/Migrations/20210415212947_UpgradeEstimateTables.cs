using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Data.EntityFramework.Migrations
{
    public partial class UpgradeEstimateTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Value",
                table: "EstimateItemTasks",
                newName: "Hours");

            migrationBuilder.AddColumn<int>(
                name: "RequestOfWorkId",
                table: "Estimates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_RequestOfWorkId",
                table: "Estimates",
                column: "RequestOfWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estimates_RequestOfWork_RequestOfWorkId",
                table: "Estimates",
                column: "RequestOfWorkId",
                principalTable: "RequestOfWork",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estimates_RequestOfWork_RequestOfWorkId",
                table: "Estimates");

            migrationBuilder.DropIndex(
                name: "IX_Estimates_RequestOfWorkId",
                table: "Estimates");

            migrationBuilder.DropColumn(
                name: "RequestOfWorkId",
                table: "Estimates");

            migrationBuilder.RenameColumn(
                name: "Hours",
                table: "EstimateItemTasks",
                newName: "Value");
        }
    }
}
