using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccomodationService.InfrastructureLib.Persistence.EF_Configurations;

internal class AccomodationConfiguration : IEntityTypeConfiguration<Accomodation>
{
    public void Configure(EntityTypeBuilder<Accomodation> builder)
    {
        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasConversion(
            id => id.Value,
            value => new AccomodationId(value));

        builder.Property(a => a.HostId)
            .HasConversion(
            id => id.Value,
            value => new HostId(value));

        builder.Property(a => a.Status)
            .HasConversion<string>();

        builder.ComplexProperty(
            a => a.Address,
            ad => ad.ToJson());

        builder.HasMany(a => a.facilities)
            .WithMany()
            .UsingEntity(j => j.ToTable("AccommodationFacilities"));
    }
}
