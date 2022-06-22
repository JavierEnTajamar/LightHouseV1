using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_RewardTypes_RewardTypeId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Sends_SendId",
                table: "Rewards");

            migrationBuilder.DropIndex(
                name: "IX_Rewards_SendId",
                table: "Rewards");

            migrationBuilder.DropColumn(
                name: "SendId",
                table: "Rewards");

            migrationBuilder.AlterColumn<int>(
                name: "RewardTypeId",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_RewardTypes_RewardTypeId",
                table: "Rewards",
                column: "RewardTypeId",
                principalTable: "RewardTypes",
                principalColumn: "RewardTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "SendId",
                table: "Rewards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_SendId",
                table: "Rewards",
                column: "SendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_RewardTypes_RewardTypeId",
                table: "Rewards",
                column: "RewardTypeId",
                principalTable: "RewardTypes",
                principalColumn: "RewardTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Sends_SendId",
                table: "Rewards",
                column: "SendId",
                principalTable: "Sends",
                principalColumn: "SendId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
