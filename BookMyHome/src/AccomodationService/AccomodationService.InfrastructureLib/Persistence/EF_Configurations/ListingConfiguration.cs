using AccomodationService.DomainLib.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccomodationService.InfrastructureLib.Persistence.EF_Configurations;

internal class ListingConfiguration : IEntityTypeConfiguration<Listing>
{
    public void Configure(EntityTypeBuilder<Listing> builder)
    {
        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .HasConversion(
            id => id.Value,
            value => new ListingId(value));

        builder.Property(l => l.Type)
            .HasConversion<string>();
    }
}
