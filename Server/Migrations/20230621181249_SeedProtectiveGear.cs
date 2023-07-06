using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedProtectiveGear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProtectiveGear",
                columns: new[] { "Id", "Size", "Type" },
                values: new object[,]
                {
                    { 1, "M", "KneePads" },
                    { 2, "XXL", "KneePads" },
                    { 3, "L", "Helmet" },
                    { 4, "XL", "Helmet" },
                    { 5, "M", "Helmet" },
                    { 6, "XXL", "Gloves" },
                    { 7, "S", "KneePads" },
                    { 8, "L", "Gloves" },
                    { 9, "XXL", "Gloves" },
                    { 10, "XL", "KneePads" },
                    { 11, "L", "Gloves" },
                    { 12, "XL", "Gloves" },
                    { 13, "M", "Gloves" },
                    { 14, "M", "KneePads" },
                    { 15, "XXL", "Helmet" },
                    { 16, "XXL", "KneePads" },
                    { 17, "M", "Helmet" },
                    { 18, "M", "KneePads" },
                    { 19, "M", "Helmet" },
                    { 20, "L", "Gloves" },
                    { 21, "XXL", "Gloves" },
                    { 22, "XXL", "KneePads" },
                    { 23, "M", "Helmet" },
                    { 24, "M", "Gloves" },
                    { 25, "L", "Gloves" },
                    { 26, "XXL", "Helmet" },
                    { 27, "XXL", "Gloves" },
                    { 28, "XL", "Helmet" },
                    { 29, "S", "Gloves" },
                    { 30, "S", "Gloves" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ProtectiveGear",
                keyColumn: "Id",
                keyValue: 30);
        }
    }
}
