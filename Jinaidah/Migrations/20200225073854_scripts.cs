using Microsoft.EntityFrameworkCore.Migrations;

namespace Jinaidah.Migrations
{
    public partial class scripts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_HoldingCategory_HoldingCategoryId",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_HoldingType_HoldingTypeId",
                table: "HoldingInfo");

            migrationBuilder.DropIndex(
                name: "IX_HoldingInfo_HoldingCategoryId",
                table: "HoldingInfo");

            migrationBuilder.DropIndex(
                name: "IX_HoldingInfo_HoldingTypeId",
                table: "HoldingInfo");

            migrationBuilder.AlterColumn<string>(
                name: "HoldingTypeId",
                table: "HoldingInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "HoldingCategoryId",
                table: "HoldingInfo",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "HoldingCategoryId1",
                table: "HoldingInfo",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HoldingTypeId1",
                table: "HoldingInfo",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ClientInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Verified",
                table: "ClientInfo",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_HoldingCategoryId1",
                table: "HoldingInfo",
                column: "HoldingCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_HoldingTypeId1",
                table: "HoldingInfo",
                column: "HoldingTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingInfo_HoldingCategory_HoldingCategoryId1",
                table: "HoldingInfo",
                column: "HoldingCategoryId1",
                principalTable: "HoldingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingInfo_HoldingType_HoldingTypeId1",
                table: "HoldingInfo",
                column: "HoldingTypeId1",
                principalTable: "HoldingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_HoldingCategory_HoldingCategoryId1",
                table: "HoldingInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_HoldingInfo_HoldingType_HoldingTypeId1",
                table: "HoldingInfo");

            migrationBuilder.DropIndex(
                name: "IX_HoldingInfo_HoldingCategoryId1",
                table: "HoldingInfo");

            migrationBuilder.DropIndex(
                name: "IX_HoldingInfo_HoldingTypeId1",
                table: "HoldingInfo");

            migrationBuilder.DropColumn(
                name: "HoldingCategoryId1",
                table: "HoldingInfo");

            migrationBuilder.DropColumn(
                name: "HoldingTypeId1",
                table: "HoldingInfo");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ClientInfo");

            migrationBuilder.DropColumn(
                name: "Verified",
                table: "ClientInfo");

            migrationBuilder.AlterColumn<int>(
                name: "HoldingTypeId",
                table: "HoldingInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "HoldingCategoryId",
                table: "HoldingInfo",
                type: "int",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_HoldingCategoryId",
                table: "HoldingInfo",
                column: "HoldingCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HoldingInfo_HoldingTypeId",
                table: "HoldingInfo",
                column: "HoldingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingInfo_HoldingCategory_HoldingCategoryId",
                table: "HoldingInfo",
                column: "HoldingCategoryId",
                principalTable: "HoldingCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HoldingInfo_HoldingType_HoldingTypeId",
                table: "HoldingInfo",
                column: "HoldingTypeId",
                principalTable: "HoldingType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
