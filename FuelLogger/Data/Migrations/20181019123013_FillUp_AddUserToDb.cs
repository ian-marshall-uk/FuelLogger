using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelLogger.Data.Migrations
{
    public partial class FillUp_AddUserToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "FillUp",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FillUp_UserId",
                table: "FillUp",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FillUp_AspNetUsers_UserId",
                table: "FillUp",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FillUp_AspNetUsers_UserId",
                table: "FillUp");

            migrationBuilder.DropIndex(
                name: "IX_FillUp_UserId",
                table: "FillUp");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FillUp");
        }
    }
}
