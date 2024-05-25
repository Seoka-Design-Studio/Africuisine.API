using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Africuisine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CulturalGroups",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CulturalGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.Id);
                    table.UniqueConstraint("AK_Profiles_Id_LUser", x => new { x.Id, x.LUser });
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Creation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LUserUpdate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeqNo = table.Column<int>(type: "int", nullable: false),
                    LCulturalGroup = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_CulturalGroups_LCulturalGroup",
                        column: x => x.LCulturalGroup,
                        principalTable: "CulturalGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
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
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
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
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CulturalGroups",
                columns: new[] { "Id", "Creation", "LUserUpdate", "LastUpdate", "Name", "SeqNo" },
                values: new object[,]
                {
                    { "0020e6c2-cae2-4e2f-9a95-1701706c0da7", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2679), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2679), "English", 0 },
                    { "02d4db1b-3317-4d12-a8ed-6c46f773c052", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2652), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2652), "Sotho", 0 },
                    { "08a2421e-ddd6-431b-ae6f-815158f24c17", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2670), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2671), "Griqua", 0 },
                    { "0e6905f3-0426-4379-ba47-9a9e41e68529", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2665), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2665), "BaPedi", 0 },
                    { "1d6238b4-5044-4231-b04d-1d5c86efd60f", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2636), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2636), "Xhosa", 0 },
                    { "3541bf74-89df-4c4d-af2e-59c6cfe36b7b", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2631), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2632), "Zulu", 0 },
                    { "3d8c07ce-066e-47bd-af20-7fdb08e726db", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2654), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2654), "Swazi", 0 },
                    { "5feafb11-ccae-4d67-b9c3-b9d3982c6890", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2677), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2677), "Indian", 0 },
                    { "7b12fec3-cba8-4ae9-bc8d-41ad4d9e435b", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2663), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2663), "Ndebele", 0 },
                    { "86cd9dd1-5e5e-45c5-841f-71afa4fc1615", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2658), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2658), "Venda", 0 },
                    { "8a76ab46-3d31-4c94-9576-626240339d12", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2675), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2675), "Coloured", 0 },
                    { "9a5d85f7-8461-4a6c-b3eb-0f37f368dd2f", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2660), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2661), "Tsonga", 0 },
                    { "9e1aebc8-1729-4c22-8e46-91f8e67b6409", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2639), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2639), "Tswana", 0 },
                    { "c3078d6c-d38d-4af2-b338-4827fe3c692a", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2668), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2668), "Khoisan", 0 },
                    { "ceef2312-f9aa-4d07-b68a-2d2ebfe16188", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2682), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(2682), "Afrikaaner", 0 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Creation", "LUserUpdate", "LastUpdate", "Name", "NormalizedName", "SeqNo" },
                values: new object[,]
                {
                    { "166c241b-1f3a-43b7-95d8-867e18b399c8", "91e143db-2107-4859-961f-0db5c0d63c26", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(1821), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(1823), "Administrator", "ADMINISTRATOR", 0 },
                    { "f471b403-1802-496d-bf24-e87e11d0ff7b", "4c2e2ea4-f118-46ff-ad67-5b9c40d0d4ea", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(1882), "", new DateTime(2024, 3, 3, 20, 2, 26, 909, DateTimeKind.Utc).AddTicks(1882), "Mobile", "MOBILE", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_LCulturalGroup",
                table: "Users",
                column: "LCulturalGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CulturalGroups");
        }
    }
}
