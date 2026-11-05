using AccomodationService.DomainLib.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccomodationService.InfrastructureLib.Persistence.EF_Configurations;

internal class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .HasConversion(
            id => id.Value,
            value => new FacilityId(value)
            );

        builder.HasData(
            new { Id = new FacilityId(Guid.Parse("68a14b26-15d6-4831-a876-221b01260c6b")), Name = "Wifi" },
            new { Id = new FacilityId(Guid.Parse("389ee76d-5478-43a4-a5f9-94a9f8133eb9")), Name = "Pool" },
            new { Id = new FacilityId(Guid.Parse("ab46c03f-4440-4ef9-8137-9dc09f82b94c")), Name = "Air Conditioning" },
            new { Id = new FacilityId(Guid.Parse("1eff118c-87f2-45f6-8f1e-2a4ce1f1ccff")), Name = "Opvaskemaskine" },
            new { Id = new FacilityId(Guid.Parse("f595c2a6-13b0-438c-bc63-c08fff41ddc4")), Name = "Gym" },
            new { Id = new FacilityId(Guid.Parse("1d4d28b2-edc2-4aaa-be9e-e855f4dd7cd3")), Name = "Grill" },
            new { Id = new FacilityId(Guid.Parse("0fb02b10-29ea-4616-83d8-5e7870e24c3f")), Name = "Hot Tub" },
            new { Id = new FacilityId(Guid.Parse("420dedfe-0bed-40ab-b036-63fbe52fbbab")), Name = "EV Lader" },
            new { Id = new FacilityId(Guid.Parse("35ae0b5a-36cf-4242-a7f3-f10a616e6626")), Name = "TV" },
            new { Id = new FacilityId(Guid.Parse("a5d70bf0-67d1-4a14-bf0b-2857d3307e11")), Name = "Vaskemaskine" },
            new { Id = new FacilityId(Guid.Parse("6f95b1bd-1039-493b-b681-b1da44d949f8")), Name = "Tørretumbler" }
            );
    }
}
