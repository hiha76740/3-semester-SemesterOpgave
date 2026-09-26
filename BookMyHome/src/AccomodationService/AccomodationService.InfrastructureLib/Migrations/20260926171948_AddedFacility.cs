using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccomodationService.InfrastructureLib.Migrations
{
    /// <inheritdoc />
    public partial class AddedFacility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccommodationFacilities",
                columns: table => new
                {
                    AccomodationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    facilitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccommodationFacilities", x => new { x.AccomodationId, x.facilitiesId });
                    table.ForeignKey(
                        name: "FK_AccommodationFacilities_Accomodations_AccomodationId",
                        column: x => x.AccomodationId,
                        principalTable: "Accomodations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccommodationFacilities_Facilities_facilitiesId",
                        column: x => x.facilitiesId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccommodationFacilities_facilitiesId",
                table: "AccommodationFacilities",
                column: "facilitiesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccommodationFacilities");

            migrationBuilder.DropTable(
                name: "Facilities");
        }
    }
}
