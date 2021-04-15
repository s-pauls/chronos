using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Data.EntityFramework.Migrations
{
    public partial class Estimate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstimateTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estimates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimateTemplateId = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrandTotal = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimates_EstimateTemplates_EstimateTemplateId",
                        column: x => x.EstimateTemplateId,
                        principalTable: "EstimateTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimateItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimateItems_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimateItemTasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EstimateItemId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Discipline = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimateItemTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimateItemTasks_EstimateItems_EstimateItemId",
                        column: x => x.EstimateItemId,
                        principalTable: "EstimateItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstimateItems_EstimateId",
                table: "EstimateItems",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimateItemTasks_EstimateItemId",
                table: "EstimateItemTasks",
                column: "EstimateItemId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimateItemTasks_Name_Discipline_EstimateItemId",
                table: "EstimateItemTasks",
                columns: new[] { "Name", "Discipline", "EstimateItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_EstimateTemplateId",
                table: "Estimates",
                column: "EstimateTemplateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstimateItemTasks");

            migrationBuilder.DropTable(
                name: "EstimateItems");

            migrationBuilder.DropTable(
                name: "Estimates");

            migrationBuilder.DropTable(
                name: "EstimateTemplates");
        }
    }
}
