using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingService.InfrastructureLib.Migrations
{
    /// <inheritdoc />
    public partial class AddedListingId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ListingId",
                table: "Bookings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Bookings");
        }
    }
}
