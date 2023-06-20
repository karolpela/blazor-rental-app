using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class PersonUniquePhoneNoEmpId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_People_EmployeeId",
                table: "People",
                column: "EmployeeId",
                unique: true,
                filter: "[Role] & 2 = 2 OR [Role] & 4 = 4 OR [Role] & 8 = 8");

            migrationBuilder.CreateIndex(
                name: "IX_People_PhoneNumber",
                table: "People",
                column: "PhoneNumber",
                unique: true,
                filter: "[Role] & 1 = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_People_EmployeeId",
                table: "People");

            migrationBuilder.DropIndex(
                name: "IX_People_PhoneNumber",
                table: "People");
        }
    }
}
