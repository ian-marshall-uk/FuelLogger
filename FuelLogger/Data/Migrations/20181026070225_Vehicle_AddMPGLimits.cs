using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelLogger.Data.Migrations
{
    public partial class Vehicle_AddMPGLimits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MPGLimits_Bad",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MPGLimits_Good",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MPGLimits_OK",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MPGLimits_Bad",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "MPGLimits_Good",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "MPGLimits_OK",
                table: "Vehicle");
        }
    }
}
