using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;

namespace AccomodationService.DomainLib.Tests;

public class AccomodationTests
{
    private readonly static HostId HostId = new(Guid.Parse("4504e34a-67a5-4cba-b029-8eb0b453b80d"));
    private readonly static string Title = "Test title";
    private readonly static string Street = "Test street 4";
    private readonly static string PostalCode = "12345";
    private readonly static string City = "Test City";

    private static Accomodation CreateAccomodation(
        HostId? hostId = null,
        string? title = null,
        string? street = null,
        string? postalCode = null,
        string? city = null
        )
    {
        return Accomodation.Create(
            hostId ?? HostId,
            title ?? Title,
            street ?? Street,
            postalCode ?? PostalCode,
            city ?? City
            );
    }

    [Fact]
    public void Create_GivenValidAccomodation_SetsStatusToActive()
    {
        // Arrange
        var expected = AccomodationStatus.Active;

        // Act
        var accomodation = CreateAccomodation();

        // Assert
        Assert.Equal(expected, accomodation.Status);
    }
}
