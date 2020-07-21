using Microsoft.EntityFrameworkCore.Migrations;

namespace Progmasters.Mordor.Migrations
{
    public partial class TryToSolveManyToOneRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Orcs_DbOrcId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_DbOrcId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "DbOrcId",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "Weapons",
                table: "Weapons",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_Weapons",
                table: "Weapons",
                column: "Weapons");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Orcs_Weapons",
                table: "Weapons",
                column: "Weapons",
                principalTable: "Orcs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Orcs_Weapons",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_Weapons",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "Weapons",
                table: "Weapons");

            migrationBuilder.AddColumn<int>(
                name: "DbOrcId",
                table: "Weapons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_DbOrcId",
                table: "Weapons",
                column: "DbOrcId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Orcs_DbOrcId",
                table: "Weapons",
                column: "DbOrcId",
                principalTable: "Orcs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
