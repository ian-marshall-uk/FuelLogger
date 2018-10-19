using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelLogger.Data.Migrations
{
    public partial class FillUp_RemoveUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FillUp");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FillUp",
                nullable: false,
                defaultValue: "");
        }
    }
}
