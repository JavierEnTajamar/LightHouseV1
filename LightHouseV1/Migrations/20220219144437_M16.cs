using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SendTypeId",
                table: "SendContents",
                newName: "SendContentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SendContentId",
                table: "SendContents",
                newName: "SendTypeId");
        }
    }
}
