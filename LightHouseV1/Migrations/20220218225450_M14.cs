using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceptionDay",
                table: "Sends",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "Deliver",
                table: "Sends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrakingCode",
                table: "Sends",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deliver",
                table: "Sends");

            migrationBuilder.DropColumn(
                name: "TrakingCode",
                table: "Sends");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReceptionDay",
                table: "Sends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
