using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WolfCoins",
                table: "Castaways",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WolfCoins",
                table: "Castaways");
        }
    }
}
