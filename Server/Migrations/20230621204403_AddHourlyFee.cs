using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddHourlyFee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "HourlyFee",
                table: "Equipment",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1,
                column: "HourlyFee",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2,
                column: "HourlyFee",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3,
                column: "HourlyFee",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4,
                column: "HourlyFee",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5,
                column: "HourlyFee",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 6,
                column: "HourlyFee",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7,
                column: "HourlyFee",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8,
                column: "HourlyFee",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9,
                column: "HourlyFee",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 10,
                column: "HourlyFee",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 11,
                column: "HourlyFee",
                value: 4m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 12,
                column: "HourlyFee",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13,
                column: "HourlyFee",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 14,
                column: "HourlyFee",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15,
                column: "HourlyFee",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 16,
                column: "HourlyFee",
                value: 5m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 18,
                column: "HourlyFee",
                value: 2m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 19,
                column: "HourlyFee",
                value: 3m);

            migrationBuilder.UpdateData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 20,
                column: "HourlyFee",
                value: 2m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HourlyFee",
                table: "Equipment");
        }
    }
}
