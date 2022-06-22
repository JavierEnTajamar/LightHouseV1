using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Castaways_CastawayId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_RewardTypes_RewardTypeId",
                table: "Rewards");

            migrationBuilder.AlterColumn<int>(
                name: "RewardTypeId",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CastawayId",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Castaways_CastawayId",
                table: "Rewards",
                column: "CastawayId",
                principalTable: "Castaways",
                principalColumn: "CastawayId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_RewardTypes_RewardTypeId",
                table: "Rewards",
                column: "RewardTypeId",
                principalTable: "RewardTypes",
                principalColumn: "RewardTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Castaways_CastawayId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_RewardTypes_RewardTypeId",
                table: "Rewards");

            migrationBuilder.AlterColumn<int>(
                name: "RewardTypeId",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CastawayId",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Castaways_CastawayId",
                table: "Rewards",
                column: "CastawayId",
                principalTable: "Castaways",
                principalColumn: "CastawayId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_RewardTypes_RewardTypeId",
                table: "Rewards",
                column: "RewardTypeId",
                principalTable: "RewardTypes",
                principalColumn: "RewardTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
