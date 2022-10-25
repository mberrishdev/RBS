using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RBS.Persistence.Migrations
{
    public partial class AddKeyToLanguage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Languages",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Languages");
        }
    }
}
