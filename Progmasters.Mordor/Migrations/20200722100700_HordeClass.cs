using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Progmasters.Mordor.Migrations
{
    public partial class HordeClass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HordeId",
                table: "Orcs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Hordes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HordeName = table.Column<string>(nullable: true),
                    DateOfLastFight = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hordes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcs_HordeId",
                table: "Orcs",
                column: "HordeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orcs_Hordes_HordeId",
                table: "Orcs",
                column: "HordeId",
                principalTable: "Hordes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orcs_Hordes_HordeId",
                table: "Orcs");

            migrationBuilder.DropTable(
                name: "Hordes");

            migrationBuilder.DropIndex(
                name: "IX_Orcs_HordeId",
                table: "Orcs");

            migrationBuilder.DropColumn(
                name: "HordeId",
                table: "Orcs");
        }
    }
}
