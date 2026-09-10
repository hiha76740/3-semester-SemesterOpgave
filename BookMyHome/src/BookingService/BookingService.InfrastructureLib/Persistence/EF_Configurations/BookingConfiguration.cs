using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingService.InfrastructureLib.Persistence.EF_Configurations;

internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Id)
            .HasConversion(
            id => id.Value,
            value => new BookingId(value));

        builder.Property(b => b.GuestId)
            .HasConversion(
            id => id.Value,
            value => new GuestId(value));

        builder.Property(b => b.AccomodationId)
            .HasConversion(
            id => id.Value,
            value => new AccomodationId(value));

        builder.Property(b => b.Status)
            .HasConversion<string>();

        builder.ComplexProperty(
            b => b.Period,
            p => p.ToJson());


    }
}
