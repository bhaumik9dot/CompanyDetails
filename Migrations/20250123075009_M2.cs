using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompanyDetails.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserMaster",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "UserMaster",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Otp",
                table: "UserMaster",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "OtpDisable",
                table: "UserMaster",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "OtpExpiryTime",
                table: "UserMaster",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "UserMaster",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoleMaster",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMaster", x => x.RoleId);
                });

            migrationBuilder.InsertData(
                table: "RoleMaster",
                columns: new[] { "RoleId", "CreatedDate", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 23, 7, 50, 9, 50, DateTimeKind.Utc).AddTicks(3110), "Administrator with full access", "Admin" },
                    { 2, new DateTime(2025, 1, 23, 7, 50, 9, 50, DateTimeKind.Utc).AddTicks(3157), "Client with limited access", "Client" }
                });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "IsActive", "IsDelete", "Otp", "OtpDisable", "OtpExpiryTime", "RoleId" },
                values: new object[] { new DateTime(2025, 1, 23, 7, 50, 9, 50, DateTimeKind.Utc).AddTicks(3033), true, false, 0, false, null, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoleMaster");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "Otp",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "OtpDisable",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "OtpExpiryTime",
                table: "UserMaster");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "UserMaster");

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 6, 36, 41, 326, DateTimeKind.Utc).AddTicks(3334));
        }
    }
}
