using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chronos.Data.EntityFramework.Migrations
{
    public partial class RequestOfWork : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RequestOfWork",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    NumberPrefix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberSuffix = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AdoId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DesiredReleaseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CSIEstimateETA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WEXEstimateETA = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SkypeGroupUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOfWork", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RequestOfWork_FDD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOfWork_FDD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOfWork_FDD_RequestOfWork_Id",
                        column: x => x.Id,
                        principalTable: "RequestOfWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestOfWork_FR",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    IsPartner = table.Column<bool>(type: "bit", nullable: false),
                    WexTeam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOfWork_FR", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOfWork_FR_RequestOfWork_Id",
                        column: x => x.Id,
                        principalTable: "RequestOfWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RequestOfWork_SOW",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    PartnerNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestOfWork_SOW", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequestOfWork_SOW_RequestOfWork_Id",
                        column: x => x.Id,
                        principalTable: "RequestOfWork",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RequestOfWork_Number",
                table: "RequestOfWork",
                column: "Number",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequestOfWork_FDD");

            migrationBuilder.DropTable(
                name: "RequestOfWork_FR");

            migrationBuilder.DropTable(
                name: "RequestOfWork_SOW");

            migrationBuilder.DropTable(
                name: "RequestOfWork");
        }
    }
}
