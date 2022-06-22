using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "SendPrice",
                table: "Sends",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BuyPrice",
                table: "Rewards",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendPrice",
                table: "Sends");

            migrationBuilder.DropColumn(
                name: "BuyPrice",
                table: "Rewards");
        }
    }
}
