using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CompanyDetails.Migrations
{
    /// <inheritdoc />
    public partial class M4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CompanyInformation",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CompanyName = table.Column<string>(type: "text", nullable: false),
                    AcquisitionDate = table.Column<string>(type: "text", nullable: false),
                    PlatformFeatures = table.Column<string>(type: "text", nullable: false),
                    IpAddressV4 = table.Column<string>(type: "text", nullable: false),
                    MacAddress = table.Column<string>(type: "text", nullable: false),
                    Canceled = table.Column<string>(type: "text", nullable: false),
                    Suspended = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    ApiBaseUrl = table.Column<string>(type: "text", nullable: false),
                    DemoAccountNodeId = table.Column<string>(type: "text", nullable: false),
                    AndroidBuild = table.Column<string>(type: "text", nullable: false),
                    ForceUpgrade = table.Column<string>(type: "text", nullable: false),
                    iOSBuild = table.Column<string>(type: "text", nullable: false),
                    AccountsCreatorURL = table.Column<string>(type: "text", nullable: false),
                    WhatsNew = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    WebsiteUrl = table.Column<string>(type: "text", nullable: true),
                    FacebookUrl = table.Column<string>(type: "text", nullable: true),
                    YouTubeUrl = table.Column<string>(type: "text", nullable: true),
                    LinkedInUrl = table.Column<string>(type: "text", nullable: true),
                    XUrl = table.Column<string>(type: "text", nullable: true),
                    ContactNumber = table.Column<string>(type: "text", nullable: true),
                    HelpPageUrl = table.Column<string>(type: "text", nullable: true),
                    PrivacyPolicyUrl = table.Column<string>(type: "text", nullable: true),
                    TermsOfServiceUrl = table.Column<string>(type: "text", nullable: true),
                    PhysicalAddress = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyInformation", x => x.CompanyId);
                });

            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 8, 4, 8, 361, DateTimeKind.Utc).AddTicks(7150));

            migrationBuilder.UpdateData(
                table: "RoleMaster",
                keyColumn: "RoleId",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 8, 4, 8, 361, DateTimeKind.Utc).AddTicks(7202));

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "UserId",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 8, 4, 8, 361, DateTimeKind.Utc).AddTicks(7060));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyInformation");

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
                column: "CreatedDate",
                value: new DateTime(2025, 1, 23, 7, 55, 33, 109, DateTimeKind.Utc).AddTicks(8301));
        }
    }
}
