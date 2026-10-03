using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccomodationService.InfrastructureLib.Migrations
{
    /// <inheritdoc />
    public partial class AddedListingStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Listings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Listings");
        }
    }
}
