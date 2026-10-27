using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingService.InfrastructureLib.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "BookingNumbers",
                startValue: 1000L);

            migrationBuilder.AddColumn<int>(
                name: "BookingNumber",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR BookingNumbers");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingNumber",
                table: "Bookings",
                column: "BookingNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Bookings_BookingNumber",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BookingNumber",
                table: "Bookings");

            migrationBuilder.DropSequence(
                name: "BookingNumbers");
        }
    }
}
