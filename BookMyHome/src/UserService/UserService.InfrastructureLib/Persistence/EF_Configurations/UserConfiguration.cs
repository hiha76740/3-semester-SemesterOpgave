using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserService.DomainLib.Entities;
using UserService.DomainLib.ValueObject;

namespace UserService.InfrastructureLib.Persistence.EF_Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .HasConversion(
            id => id.Value,
            value => new UserId(value)
            );

        builder.Property(u => u.Birthdate)
            .HasConversion(
            date => date.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
            .HasColumnType("date");

        builder.ComplexProperty(
            u => u.Address);

        builder.ComplexProperty(
            u => u.PhoneNumber);

        builder.Property(u => u.Email)
            .HasConversion(
            email => email.Value,
            value => new Email(value));

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.HasIndex(u => u.Username)
            .IsUnique();

        builder.Property(u => u.Role)
            .HasConversion<string>();


    }
}
