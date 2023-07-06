using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEquipmentSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Purpose",
                value: "Performance");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Purpose",
                value: "Figure");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Purpose",
                value: "Figure");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Purpose",
                value: "Figure");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5,
                column: "Purpose",
                value: "Performance");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8,
                column: "Purpose",
                value: "Performance");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9,
                column: "Purpose",
                value: "Performance");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 12,
                column: "Purpose",
                value: "Performance");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 14,
                column: "Purpose",
                value: "Figure");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15,
                column: "Purpose",
                value: "Performance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1,
                column: "Purpose",
                value: "Speed Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2,
                column: "Purpose",
                value: "Figure Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3,
                column: "Purpose",
                value: "Figure Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4,
                column: "Purpose",
                value: "Figure Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5,
                column: "Purpose",
                value: "Speed");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8,
                column: "Purpose",
                value: "Speed Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9,
                column: "Purpose",
                value: "Speed");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 12,
                column: "Purpose",
                value: "Speed Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 14,
                column: "Purpose",
                value: "Figure Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15,
                column: "Purpose",
                value: "Speed");
        }
    }
}
