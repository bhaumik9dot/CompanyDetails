using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDetails.Migrations
{
    /// <inheritdoc />
    public partial class M6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "CompanyInformation",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "CompanyInformation",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 12, 5, 35, 832, DateTimeKind.Utc).AddTicks(2895));

            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 12, 5, 35, 832, DateTimeKind.Utc).AddTicks(2961));

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 12, 5, 35, 832, DateTimeKind.Utc).AddTicks(2819));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "CompanyInformation");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "CompanyInformation");

            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 11, 53, 12, 440, DateTimeKind.Utc).AddTicks(2100));

            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 11, 53, 12, 440, DateTimeKind.Utc).AddTicks(2149));

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 11, 53, 12, 440, DateTimeKind.Utc).AddTicks(2023));
        }
    }
}
