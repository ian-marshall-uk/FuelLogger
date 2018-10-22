using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelLogger.Data.Migrations
{
    public partial class FillUp_AddMPG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MPG",
                table: "FillUp",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MPG",
                table: "FillUp");
        }
    }
}
