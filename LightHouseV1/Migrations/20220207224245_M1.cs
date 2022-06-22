using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LightHouseV1.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "ClaimedBys",
                columns: table => new
                {
                    ClaimedById = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClaimedByType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClaimedBys", x => x.ClaimedById);
                });

            migrationBuilder.CreateTable(
                name: "RewardCompositions",
                columns: table => new
                {
                    RewardCompositionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardComponents = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardCompositions", x => x.RewardCompositionId);
                });

            migrationBuilder.CreateTable(
                name: "RewardStatuses",
                columns: table => new
                {
                    RewardStatusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardStatusType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardStatuses", x => x.RewardStatusId);
                });

            migrationBuilder.CreateTable(
                name: "RewardTypes",
                columns: table => new
                {
                    RewardTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RewardTypes", x => x.RewardTypeId);
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

            migrationBuilder.CreateTable(
                name: "Templates",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Templates", x => x.TemplateId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Castaways",
                columns: table => new
                {
                    CastawayId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CastawayTwitchName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawaySecondLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayRoadTypeId = table.Column<int>(type: "int", nullable: true),
                    CastawayRoadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayHomeNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayHomePortal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayHomeFloor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastawayHomeDoor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Castaways", x => x.CastawayId);
                    table.ForeignKey(
                        name: "FK_Castaways_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Castaways_CastawayRoadTypes_CastawayRoadTypeId",
                        column: x => x.CastawayRoadTypeId,
                        principalTable: "CastawayRoadTypes",
                        principalColumn: "CastawayRoadTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sends",
                columns: table => new
                {
                    SendId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendTypeId = table.Column<int>(type: "int", nullable: true),
                    SendDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReceptionDay = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sends", x => x.SendId);
                    table.ForeignKey(
                        name: "FK_Sends_SendType_SendTypeId",
                        column: x => x.SendTypeId,
                        principalTable: "SendType",
                        principalColumn: "SendTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rewards",
                columns: table => new
                {
                    RewardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RewardTypeId = table.Column<int>(type: "int", nullable: false),
                    ClaimedById = table.Column<int>(type: "int", nullable: true),
                    ClaimDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RewardColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RewardSprayColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TemplateId = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    RewardCompositionId = table.Column<int>(type: "int", nullable: true),
                    RewardStatusId = table.Column<int>(type: "int", nullable: true),
                    SendId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rewards", x => x.RewardId);
                    table.ForeignKey(
                        name: "FK_Rewards_ClaimedBys_ClaimedById",
                        column: x => x.ClaimedById,
                        principalTable: "ClaimedBys",
                        principalColumn: "ClaimedById",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rewards_RewardCompositions_RewardCompositionId",
                        column: x => x.RewardCompositionId,
                        principalTable: "RewardCompositions",
                        principalColumn: "RewardCompositionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rewards_RewardStatuses_RewardStatusId",
                        column: x => x.RewardStatusId,
                        principalTable: "RewardStatuses",
                        principalColumn: "RewardStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rewards_RewardTypes_RewardTypeId",
                        column: x => x.RewardTypeId,
                        principalTable: "RewardTypes",
                        principalColumn: "RewardTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rewards_Sends_SendId",
                        column: x => x.SendId,
                        principalTable: "Sends",
                        principalColumn: "SendId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rewards_Templates_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "Templates",
                        principalColumn: "TemplateId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SendContents",
                columns: table => new
                {
                    SendTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendId = table.Column<int>(type: "int", nullable: true),
                    RewardId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendContents", x => x.SendTypeId);
                    table.ForeignKey(
                        name: "FK_SendContents_Rewards_RewardId",
                        column: x => x.RewardId,
                        principalTable: "Rewards",
                        principalColumn: "RewardId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SendContents_Sends_SendId",
                        column: x => x.SendId,
                        principalTable: "Sends",
                        principalColumn: "SendId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Castaways_CastawayRoadTypeId",
                table: "Castaways",
                column: "CastawayRoadTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Castaways_UserId",
                table: "Castaways",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_ClaimedById",
                table: "Rewards",
                column: "ClaimedById");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_RewardCompositionId",
                table: "Rewards",
                column: "RewardCompositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_RewardStatusId",
                table: "Rewards",
                column: "RewardStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_RewardTypeId",
                table: "Rewards",
                column: "RewardTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_SendId",
                table: "Rewards",
                column: "SendId");

            migrationBuilder.CreateIndex(
                name: "IX_Rewards_TemplateId",
                table: "Rewards",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_SendContents_RewardId",
                table: "SendContents",
                column: "RewardId");

            migrationBuilder.CreateIndex(
                name: "IX_SendContents_SendId",
                table: "SendContents",
                column: "SendId");

            migrationBuilder.CreateIndex(
                name: "IX_Sends_SendTypeId",
                table: "Sends",
                column: "SendTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Castaways");

            migrationBuilder.DropTable(
                name: "SendContents");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CastawayRoadTypes");

            migrationBuilder.DropTable(
                name: "Rewards");

            migrationBuilder.DropTable(
                name: "ClaimedBys");

            migrationBuilder.DropTable(
                name: "RewardCompositions");

            migrationBuilder.DropTable(
                name: "RewardStatuses");

            migrationBuilder.DropTable(
                name: "RewardTypes");

            migrationBuilder.DropTable(
                name: "Sends");

            migrationBuilder.DropTable(
                name: "Templates");

            migrationBuilder.DropTable(
                name: "SendType");
        }
    }
}
