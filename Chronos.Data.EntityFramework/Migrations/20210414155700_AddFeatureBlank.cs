using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Data.EntityFramework.Migrations
{
    public partial class AddFeatureBlank : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FeatureBlank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestOfWorkId = table.Column<int>(type: "int", nullable: false),
                    EstimateId = table.Column<int>(type: "int", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeatureBlank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeatureBlank_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FeatureBlank_RequestOfWork_RequestOfWorkId",
                        column: x => x.RequestOfWorkId,
                        principalTable: "RequestOfWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeatureBlank_EstimateId",
                table: "FeatureBlank",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_FeatureBlank_RequestOfWorkId",
                table: "FeatureBlank",
                column: "RequestOfWorkId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeatureBlank");
        }
    }
}
