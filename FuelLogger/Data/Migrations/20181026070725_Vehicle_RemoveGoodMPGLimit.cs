using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelLogger.Data.Migrations
{
    public partial class Vehicle_RemoveGoodMPGLimit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MPGLimits_Good",
                table: "Vehicle");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MPGLimits_Good",
                table: "Vehicle",
                nullable: false,
                defaultValue: 0);
        }
    }
}
