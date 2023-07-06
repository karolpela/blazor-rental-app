using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedEquipment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Discriminator", "IsFunctional", "Purpose", "Size", "WheelHardness" },
                values: new object[,]
                {
                    { 1, "RollerSkates", true, "Speed Skating", 44m, 36 },
                    { 2, "RollerSkates", false, "Figure Skating", 46m, 75 },
                    { 3, "RollerSkates", true, "Figure Skating", 47m, 10 }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BearingType", "Discriminator", "IsFunctional", "Purpose", "Size", "WheelDiameter" },
                values: new object[] { 4, "ABEC-5", "InlineSkates", true, "Figure Skating", 47m, 15m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BladeMaterial", "Discriminator", "HasToePick", "IsFunctional", "Purpose", "Size" },
                values: new object[] { 5, "Steel", "IceSkates", true, true, "Speed Skating", 38m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BearingType", "Discriminator", "IsFunctional", "Purpose", "Size", "WheelDiameter" },
                values: new object[] { 6, "ABEC-9", "InlineSkates", true, "Hockey", 47m, 88m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BladeMaterial", "Discriminator", "HasToePick", "IsFunctional", "Purpose", "Size" },
                values: new object[] { 7, "Carbon Fiber", "IceSkates", true, false, "Figure Skating", 47m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BearingType", "Discriminator", "IsFunctional", "Purpose", "Size", "WheelDiameter" },
                values: new object[] { 8, "ABEC-9", "InlineSkates", true, "Speed Skating", 42m, 30m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BladeMaterial", "Discriminator", "HasToePick", "IsFunctional", "Purpose", "Size" },
                values: new object[,]
                {
                    { 9, "Steel", "IceSkates", true, true, "Speed Skating", 38m },
                    { 10, "Carbon Fiber", "IceSkates", true, false, "Hockey", 43m },
                    { 11, "Steel", "IceSkates", false, false, "Hockey", 47m }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BearingType", "Discriminator", "IsFunctional", "Purpose", "Size", "WheelDiameter" },
                values: new object[] { 12, "ABEC-7", "InlineSkates", true, "Speed Skating", 41m, 38m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BladeMaterial", "Discriminator", "HasToePick", "IsFunctional", "Purpose", "Size" },
                values: new object[] { 13, "Steel", "IceSkates", false, true, "Figure Skating", 42m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Discriminator", "IsFunctional", "Purpose", "Size", "WheelHardness" },
                values: new object[] { 14, "RollerSkates", false, "Figure Skating", 42m, 91 });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BladeMaterial", "Discriminator", "HasToePick", "IsFunctional", "Purpose", "Size" },
                values: new object[,]
                {
                    { 15, "Aluminum", "IceSkates", false, false, "Speed Skating", 37m },
                    { 16, "Steel", "IceSkates", false, true, "Hockey", 45m }
                });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BearingType", "Discriminator", "IsFunctional", "Purpose", "Size", "WheelDiameter" },
                values: new object[] { 18, "ABEC-3", "InlineSkates", false, "Hockey", 45m, 22m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "BladeMaterial", "Discriminator", "HasToePick", "IsFunctional", "Purpose", "Size" },
                values: new object[] { 19, "Plastic", "IceSkates", true, true, "Figure Skating", 42m });

            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Discriminator", "IsFunctional", "Purpose", "Size", "WheelHardness" },
                values: new object[] { 20, "RollerSkates", true, "Hockey", 43m, 89 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
