using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tracking.Core.Migrations
{
    public partial class initialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "operation_systems",
                columns: table => new
                {
                    id = table.Column<byte>(type: "tinyint", nullable: false),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operation_systems", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tracking",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    client_id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    client_ip = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    client_country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    site_ip = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    site_country = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    domain = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    operation_system_id = table.Column<byte>(type: "tinyint", nullable: false),
                    request_date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tracking", x => x.id);
                    table.ForeignKey(
                        name: "FK_tracking_operation_systems_operation_system_id",
                        column: x => x.operation_system_id,
                        principalTable: "operation_systems",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_operation_systems_name",
                table: "operation_systems",
                column: "name",
                unique: true,
                filter: "[name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tracking_client_country",
                table: "tracking",
                column: "client_country");

            migrationBuilder.CreateIndex(
                name: "IX_tracking_client_id",
                table: "tracking",
                column: "client_id",
                unique: true,
                filter: "[client_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tracking_operation_system_id",
                table: "tracking",
                column: "operation_system_id");

            migrationBuilder.CreateIndex(
                name: "IX_tracking_request_date",
                table: "tracking",
                column: "request_date");

            migrationBuilder.CreateIndex(
                name: "IX_tracking_site_country",
                table: "tracking",
                column: "site_country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tracking");

            migrationBuilder.DropTable(
                name: "operation_systems");
        }
    }
}
