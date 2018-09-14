using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FuelLogger.Data.Migrations
{
    public partial class AddFillUpsToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType");

            migrationBuilder.RenameTable(
                name: "CategoryType",
                newName: "Vehicle");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "FillUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    OdometerReading = table.Column<int>(nullable: false),
                    Litres = table.Column<double>(nullable: false),
                    PricePerLitre = table.Column<double>(nullable: false),
                    Note = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FillUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FillUp_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FillUp_VehicleId",
                table: "FillUp",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FillUp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vehicle",
                table: "Vehicle");

            migrationBuilder.RenameTable(
                name: "Vehicle",
                newName: "CategoryType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryType",
                table: "CategoryType",
                column: "Id");
        }
    }
}
