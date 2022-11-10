using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RBS.Persistence.Migrations
{
    public partial class AddCoordinatesToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "XCoordinage",
                table: "Tables",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "YCoordinage",
                table: "Tables",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "XCoordinage",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "YCoordinage",
                table: "Tables");
        }
    }
}
