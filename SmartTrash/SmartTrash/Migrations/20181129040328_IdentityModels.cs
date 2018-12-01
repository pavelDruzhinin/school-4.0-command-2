using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartTrash.Migrations
{
    public partial class IdentityModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.79087f, 34.36776f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78953f, 34.37f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Longitude",
                value: 34.3732f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Latitude",
                value: 61.8019f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.80639f, 34.33181f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Latitude",
                value: 61.80109f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.79863f, 34.32402f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 9,
                column: "Latitude",
                value: 61.7935f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 10,
                column: "Latitude",
                value: 61.79022f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78534f, 34.34936f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78695f, 34.36066f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 15,
                column: "Longitude",
                value: 34.36686f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78819f, 34.37271f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78965f, 34.37432f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 18,
                column: "Longitude",
                value: 34.37862f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 19,
                column: "Longitude",
                value: 34.37489f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 20,
                column: "Latitude",
                value: 61.80373f);

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
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.79087f, 34.36776f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78953f, 34.37f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 3,
                column: "Longitude",
                value: 34.3732f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 4,
                column: "Latitude",
                value: 61.8019f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.80639f, 34.33181f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 6,
                column: "Latitude",
                value: 61.80109f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.79863f, 34.32402f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 9,
                column: "Latitude",
                value: 61.7935f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 10,
                column: "Latitude",
                value: 61.79022f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78534f, 34.34936f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78695f, 34.36066f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 15,
                column: "Longitude",
                value: 34.36686f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78819f, 34.37271f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Latitude", "Longitude" },
                values: new object[] { 61.78965f, 34.37432f });

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 18,
                column: "Longitude",
                value: 34.37862f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 19,
                column: "Longitude",
                value: 34.37489f);

            migrationBuilder.UpdateData(
                table: "WasteCollectionAreas",
                keyColumn: "Id",
                keyValue: 20,
                column: "Latitude",
                value: 61.80373f);
        }
    }
}
