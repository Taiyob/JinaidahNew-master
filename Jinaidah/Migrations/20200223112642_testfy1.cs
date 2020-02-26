using Microsoft.EntityFrameworkCore.Migrations;

namespace Jinaidah.Migrations
{
    public partial class testfy1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoldingType_WaterRate_WaterRateId",
                table: "HoldingType");

            migrationBuilder.DropIndex(
                name: "IX_HoldingType_WaterRateId",
                table: "HoldingType");

            migrationBuilder.DropColumn(
                name: "WaterRateId",
                table: "HoldingType");

            migrationBuilder.AddColumn<int>(
                name: "HoldingTypeId",
                table: "WaterRate",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_WaterRate_HoldingTypeId",
                table: "WaterRate",
                column: "HoldingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_WaterRate_HoldingType_HoldingTypeId",
                table: "WaterRate",
                column: "HoldingTypeId",
                principalTable: "HoldingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WaterRate_HoldingType_HoldingTypeId",
                table: "WaterRate");

            migrationBuilder.DropIndex(
                name: "IX_WaterRate_HoldingTypeId",
                table: "WaterRate");

            migrationBuilder.DropColumn(
                name: "HoldingTypeId",
                table: "WaterRate");

            migrationBuilder.AddColumn<int>(
                name: "WaterRateId",
                table: "HoldingType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HoldingType_WaterRateId",
                table: "HoldingType",
                column: "WaterRateId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingType_WaterRate_WaterRateId",
                table: "HoldingType",
                column: "WaterRateId",
                principalTable: "WaterRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
