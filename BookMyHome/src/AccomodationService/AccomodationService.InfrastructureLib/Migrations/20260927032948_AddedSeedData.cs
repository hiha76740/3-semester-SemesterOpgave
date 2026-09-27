using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccomodationService.InfrastructureLib.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0fb02b10-29ea-4616-83d8-5e7870e24c3f"), "Hot Tub" },
                    { new Guid("1d4d28b2-edc2-4aaa-be9e-e855f4dd7cd3"), "Grill" },
                    { new Guid("1eff118c-87f2-45f6-8f1e-2a4ce1f1ccff"), "Opvaskemaskine" },
                    { new Guid("35ae0b5a-36cf-4242-a7f3-f10a616e6626"), "TV" },
                    { new Guid("389ee76d-5478-43a4-a5f9-94a9f8133eb9"), "Pool" },
                    { new Guid("420dedfe-0bed-40ab-b036-63fbe52fbbab"), "EV Lader" },
                    { new Guid("68a14b26-15d6-4831-a876-221b01260c6b"), "Wifi" },
                    { new Guid("6f95b1bd-1039-493b-b681-b1da44d949f8"), "Tørretumbler" },
                    { new Guid("a5d70bf0-67d1-4a14-bf0b-2857d3307e11"), "Vaskemaskine" },
                    { new Guid("ab46c03f-4440-4ef9-8137-9dc09f82b94c"), "Air Conditioning" },
                    { new Guid("f595c2a6-13b0-438c-bc63-c08fff41ddc4"), "Gym" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("0fb02b10-29ea-4616-83d8-5e7870e24c3f"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("1d4d28b2-edc2-4aaa-be9e-e855f4dd7cd3"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("1eff118c-87f2-45f6-8f1e-2a4ce1f1ccff"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("35ae0b5a-36cf-4242-a7f3-f10a616e6626"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("389ee76d-5478-43a4-a5f9-94a9f8133eb9"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("420dedfe-0bed-40ab-b036-63fbe52fbbab"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("68a14b26-15d6-4831-a876-221b01260c6b"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("6f95b1bd-1039-493b-b681-b1da44d949f8"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("a5d70bf0-67d1-4a14-bf0b-2857d3307e11"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("ab46c03f-4440-4ef9-8137-9dc09f82b94c"));

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: new Guid("f595c2a6-13b0-438c-bc63-c08fff41ddc4"));
        }
    }
}
