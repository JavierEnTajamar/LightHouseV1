using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CastawayId",
                table: "Rewards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_CastawayId",
                table: "Rewards",
                column: "CastawayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Castaways_CastawayId",
                table: "Rewards",
                column: "CastawayId",
                principalTable: "Castaways",
                principalColumn: "CastawayId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Castaways_CastawayId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_CastawayId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "CastawayId",
                table: "Rewards");
        }
    }
}
