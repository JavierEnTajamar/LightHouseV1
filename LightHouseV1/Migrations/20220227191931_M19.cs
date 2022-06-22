using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "BuyPrice",
                table: "Rewards",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "BuyPrice",
                table: "Rewards",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
