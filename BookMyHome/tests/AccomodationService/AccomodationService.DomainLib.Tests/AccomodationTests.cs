using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;
using AccomodationService.DomainLib.ValueObjects;

namespace AccomodationService.DomainLib.Tests;

public class AccomodationTests
{
    private static readonly HostId s_hostId = new(Guid.Parse("4504e34a-67a5-4cba-b029-8eb0b453b80d"));
    private static readonly string s_title = "Test title";
    private static readonly string s_street = "Test street 4";
    private static readonly string s_postalCode = "12345";
    private static readonly string s_city = "Test City";
    private static readonly string s_country = "Denmark";

    private static readonly List<Facility> s_facilitiesIds = [];

    private static Accomodation CreateAccomodation(
        HostId? hostId = null,
        string? title = null,
        string? street = null,
        string? postalCode = null,
        string? city = null,
        string? country = null,
        List<Facility>? facilitiesIds = null
        )
    {
        return Accomodation.Create(
            hostId ?? s_hostId,
            title ?? s_title,
            street ?? s_street,
            postalCode ?? s_postalCode,
            city ?? s_city,
            country ?? s_country,
            facilitiesIds ?? s_facilitiesIds
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
