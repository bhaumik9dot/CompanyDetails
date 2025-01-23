using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyDetails.Migrations
{
    /// <inheritdoc />
    public partial class M3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 7, 55, 33, 109, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 7, 55, 33, 109, DateTimeKind.Utc).AddTicks(8423));

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 1, 23, 7, 55, 33, 109, DateTimeKind.Utc).AddTicks(8301), "abcadmin@yopmail.com", "ABC", "Technology" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 7, 50, 9, 50, DateTimeKind.Utc).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 7, 50, 9, 50, DateTimeKind.Utc).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Email", "FirstName", "LastName" },
                values: new object[] { new DateTime(2025, 1, 23, 7, 50, 9, 50, DateTimeKind.Utc).AddTicks(3033), "v2accountadmin@yopmail.com", "V2Account", "CRM" });
        }
    }
}
