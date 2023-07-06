using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedRental : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rentals",
                columns: new[] { "Id", "ClientId", "EndDate", "EquipmentDamaged", "EquipmentId", "ScheduledEndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 4, new DateTimeOffset(new DateTime(2022, 6, 19, 12, 12, 33, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 11, new DateTimeOffset(new DateTime(2022, 6, 19, 12, 12, 33, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 6, 13, 12, 12, 33, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 2, 1, new DateTimeOffset(new DateTime(2022, 3, 30, 9, 11, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, 2, new DateTimeOffset(new DateTime(2022, 3, 30, 9, 11, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 3, 27, 9, 11, 40, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 3, 1, new DateTimeOffset(new DateTime(2022, 9, 10, 10, 43, 38, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 1, new DateTimeOffset(new DateTime(2022, 9, 10, 10, 43, 38, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 9, 10, 10, 43, 38, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 4, 6, new DateTimeOffset(new DateTime(2022, 5, 28, 23, 33, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, 10, new DateTimeOffset(new DateTime(2022, 5, 27, 23, 33, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 5, 25, 23, 33, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 5, 1, new DateTimeOffset(new DateTime(2023, 3, 26, 5, 0, 34, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 1, new DateTimeOffset(new DateTime(2023, 3, 25, 5, 0, 34, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 3, 25, 5, 0, 34, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 6, 11, new DateTimeOffset(new DateTime(2023, 6, 3, 7, 55, 37, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 4, new DateTimeOffset(new DateTime(2023, 6, 3, 7, 55, 37, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2023, 6, 2, 7, 55, 37, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 7, 1, new DateTimeOffset(new DateTime(2022, 2, 4, 7, 42, 18, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, 12, new DateTimeOffset(new DateTime(2022, 2, 4, 7, 42, 18, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 28, 7, 42, 18, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 8, 2, new DateTimeOffset(new DateTime(2022, 10, 13, 0, 53, 3, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), true, 1, new DateTimeOffset(new DateTime(2022, 10, 12, 0, 53, 3, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 10, 10, 0, 53, 3, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 9, 6, new DateTimeOffset(new DateTime(2022, 6, 14, 18, 53, 37, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 10, new DateTimeOffset(new DateTime(2022, 6, 14, 18, 53, 37, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 6, 10, 18, 53, 37, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 10, 1, new DateTimeOffset(new DateTime(2022, 8, 16, 0, 7, 38, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 9, new DateTimeOffset(new DateTime(2022, 8, 16, 0, 7, 38, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 8, 10, 0, 7, 38, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) },
                    { 11, 4, new DateTimeOffset(new DateTime(2022, 1, 24, 21, 2, 29, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), false, 6, new DateTimeOffset(new DateTime(2022, 1, 23, 21, 2, 29, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2022, 1, 23, 21, 2, 29, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Rentals",
                keyColumn: "Id",
                keyValue: 11);
        }
    }
}
