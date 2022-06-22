using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "SendPrice",
                table: "Sends",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SendPrice",
                table: "Sends",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);
        }
    }
}
