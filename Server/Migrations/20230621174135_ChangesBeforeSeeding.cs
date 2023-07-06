using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalApp.Server.Migrations
{
    /// <inheritdoc />
    public partial class ChangesBeforeSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rentals_Insurances_Id",
                table: "Rentals");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Rentals",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "RentalId",
                table: "Insurances",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Insurances_RentalId",
                table: "Insurances",
                column: "RentalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurances_Rentals_RentalId",
                table: "Insurances",
                column: "RentalId",
                principalTable: "Rentals",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurances_Rentals_RentalId",
                table: "Insurances");

            migrationBuilder.DropIndex(
                name: "IX_Insurances_RentalId",
                table: "Insurances");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "Insurances");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Rentals",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rentals_Insurances_Id",
                table: "Rentals",
                column: "Id",
                principalTable: "Insurances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
