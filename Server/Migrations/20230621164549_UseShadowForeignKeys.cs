using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class UseShadowForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "Insurances",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5,
                column: "Purpose",
                value: "Speed");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7,
                column: "Purpose",
                value: "Figure");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9,
                column: "Purpose",
                value: "Speed");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13,
                column: "Purpose",
                value: "Figure");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15,
                column: "Purpose",
                value: "Speed");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 19,
                column: "Purpose",
                value: "Figure");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Insurances");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5,
                column: "Purpose",
                value: "Speed Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7,
                column: "Purpose",
                value: "Figure Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9,
                column: "Purpose",
                value: "Speed Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13,
                column: "Purpose",
                value: "Figure Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15,
                column: "Purpose",
                value: "Speed Skating");

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 19,
                column: "Purpose",
                value: "Figure Skating");
        }
    }
}
