using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddSamplePesel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pesel",
                value: "34556468065");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pesel",
                value: "66100957666");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                column: "Pesel",
                value: "84576111796");

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9,
                column: "Pesel",
                value: "98155940198");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1,
                column: "Pesel",
                value: null);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3,
                column: "Pesel",
                value: null);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6,
                column: "Pesel",
                value: null);

            migrationBuilder.UpdateData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9,
                column: "Pesel",
                value: null);
        }
    }
}
