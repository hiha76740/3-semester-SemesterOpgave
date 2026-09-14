using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.Enums;

namespace AccomodationService.DomainLib.Tests;

public class AccomodationTests
{
    private readonly static string Title = "Test title";

    private static Accomodation CreateAccomodation(
        string? title = null
        )
    {
        return Accomodation.Create(
            title ?? Title);
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
