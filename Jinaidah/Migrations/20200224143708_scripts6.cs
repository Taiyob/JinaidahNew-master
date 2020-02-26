using Microsoft.EntityFrameworkCore.Migrations;

namespace Jinaidah.Migrations
{
    public partial class scripts6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WaterRate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "WaterConnection",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "WaterBill",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Ispaid",
                table: "TaxBill",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WaterRate");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "WaterConnection");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "WaterBill");

            migrationBuilder.DropColumn(
                name: "Ispaid",
                table: "TaxBill");
        }
    }
}
