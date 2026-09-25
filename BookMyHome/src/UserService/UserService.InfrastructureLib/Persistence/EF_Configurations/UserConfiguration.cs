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

        builder.ComplexProperty(
            u => u.Address,
            a => a.ToJson());

        builder.ComplexProperty(
            u => u.PhoneNumber,
            pn => pn.ToJson()
            );

        builder.Property(u => u.Email)
            .HasConversion(
            email => email.EmailAddress,
            value => new Email(value));

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.Role)
            .HasConversion<string>();


    }
}
