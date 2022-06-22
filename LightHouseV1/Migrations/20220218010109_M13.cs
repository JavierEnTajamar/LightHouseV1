using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_ClaimedBys_ClaimedById",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_RewardCompositions_RewardCompositionId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_RewardStatuses_RewardStatusId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Templates_TemplateId",
                table: "Rewards");

            migrationBuilder.AlterColumn<int>(
                name: "TemplateId",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RewardStatusId",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RewardCompositionId",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClaimedById",
                table: "Rewards",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_ClaimedBys_ClaimedById",
                table: "Rewards",
                column: "ClaimedById",
                principalTable: "ClaimedBys",
                principalColumn: "ClaimedById",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_RewardCompositions_RewardCompositionId",
                table: "Rewards",
                column: "RewardCompositionId",
                principalTable: "RewardCompositions",
                principalColumn: "RewardCompositionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_RewardStatuses_RewardStatusId",
                table: "Rewards",
                column: "RewardStatusId",
                principalTable: "RewardStatuses",
                principalColumn: "RewardStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Templates_TemplateId",
                table: "Rewards",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "TemplateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_ClaimedBys_ClaimedById",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_RewardCompositions_RewardCompositionId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_RewardStatuses_RewardStatusId",
                table: "Rewards");

            migrationBuilder.DropForeignKey(
                name: "FK_Rewards_Templates_TemplateId",
                table: "Rewards");

            migrationBuilder.AlterColumn<int>(
                name: "TemplateId",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RewardStatusId",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RewardCompositionId",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClaimedById",
                table: "Rewards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_ClaimedBys_ClaimedById",
                table: "Rewards",
                column: "ClaimedById",
                principalTable: "ClaimedBys",
                principalColumn: "ClaimedById",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_RewardCompositions_RewardCompositionId",
                table: "Rewards",
                column: "RewardCompositionId",
                principalTable: "RewardCompositions",
                principalColumn: "RewardCompositionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_RewardStatuses_RewardStatusId",
                table: "Rewards",
                column: "RewardStatusId",
                principalTable: "RewardStatuses",
                principalColumn: "RewardStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Rewards_Templates_TemplateId",
                table: "Rewards",
                column: "TemplateId",
                principalTable: "Templates",
                principalColumn: "TemplateId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
