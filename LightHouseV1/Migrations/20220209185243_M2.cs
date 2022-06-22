using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castaways_CastawayRoadTypes_CastawayRoadTypeId",
                table: "Castaways");

            migrationBuilder.DropForeignKey(
                name: "FK_Sends_SendType_SendTypeId",
                table: "Sends");

            migrationBuilder.DropTable(
                name: "CastawayRoadTypes");

            migrationBuilder.DropTable(
                name: "SendType");

            migrationBuilder.DropIndex(
                name: "IX_Sends_SendTypeId",
                table: "Sends");

            migrationBuilder.DropIndex(
                name: "IX_Castaways_CastawayRoadTypeId",
                table: "Castaways");

            migrationBuilder.DropColumn(
                name: "SendTypeId",
                table: "Sends");

            migrationBuilder.DropColumn(
                name: "CastawayRoadTypeId",
                table: "Castaways");

            migrationBuilder.AddColumn<int>(
                name: "SendType",
                table: "Sends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CastawayRoadType",
                table: "Castaways",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SendType",
                table: "Sends");

            migrationBuilder.DropColumn(
                name: "CastawayRoadType",
                table: "Castaways");

            migrationBuilder.AddColumn<int>(
                name: "SendTypeId",
                table: "Sends",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CastawayRoadTypeId",
                table: "Castaways",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CastawayRoadTypes",
                columns: table => new
                {
                    CastawayRoadTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CastawayRoadTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastawayRoadTypes", x => x.CastawayRoadTypeId);
                });

            migrationBuilder.CreateTable(
                name: "SendType",
                columns: table => new
                {
                    SendTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendType", x => x.SendTypeId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sends_SendTypeId",
                table: "Sends",
                column: "SendTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Castaways_CastawayRoadTypeId",
                table: "Castaways",
                column: "CastawayRoadTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Castaways_CastawayRoadTypes_CastawayRoadTypeId",
                table: "Castaways",
                column: "CastawayRoadTypeId",
                principalTable: "CastawayRoadTypes",
                principalColumn: "CastawayRoadTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sends_SendType_SendTypeId",
                table: "Sends",
                column: "SendTypeId",
                principalTable: "SendType",
                principalColumn: "SendTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
