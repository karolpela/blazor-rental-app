using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class SeedPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DismissalDate", "EmployeeId", "EmploymentDate", "FirstName", "LastName", "Pesel", "PhoneNumber", "Role", "SupervisorId" },
                values: new object[,]
                {
                    { 1, null, null, null, "Aubrey", "Hurworth", null, "190684116", 1, null },
                    { 2, null, "e1", null, "Duncan", "Agius", null, "456100995", 3, null },
                    { 3, null, "e2", null, "Colby", "Lisciandro", null, "391899786", 1, null },
                    { 4, null, null, null, "Sherilyn", "Cornewall", null, "198315600", 1, null },
                    { 5, null, "e3", null, "Isadora", "Casel", null, null, 4, null },
                    { 6, null, null, null, "Hermina", "Edgley", null, "882627905", 1, null },
                    { 7, null, "e4", null, "Beckie", "Fann", null, null, 4, null },
                    { 8, null, "e5", null, "Shelley", "Molyneaux", null, null, 2, null },
                    { 9, null, "e6", null, "Yasmin", "Beecker", null, "362667890", 3, null },
                    { 10, null, "e7", null, "Nollie", "Anglish", null, null, 4, null },
                    { 11, null, "e8", null, "Carmencita", "Tattam", null, "800838101", 5, null },
                    { 12, null, "e9", null, "Lucas", "Faughny", null, null, 2, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
