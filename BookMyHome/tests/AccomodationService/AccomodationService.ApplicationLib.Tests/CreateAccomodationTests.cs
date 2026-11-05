using AccomodationService.ApplicationLib.Handlers.Accomodations;
using AccomodationService.ApplicationLib.Handlers.Services;
using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs.Accomodations;
using AccomodationService.FacadeLib.Commands.Interfaces.Accomodations;
using Moq;

namespace AccomodationService.ApplicationLib.Tests;

public class CreateAccomodationTests
{
    [Fact]
    public async Task Handle_GivenValidData_CallsAddAndSave()
    {
        // Arrange
        var hostId = new HostId(Guid.NewGuid());
        var title = "My new house";
        var street = "Test street 1";
        var postalCode = "12345";
        var city = "Test city";
        var country = "Denmark";
        var facilities = new List<Guid>();

        var mockAccomodationRepo = new Mock<IAccomodationRepository>();

        var mockImageStorage = new Mock<IImageStorageService>();

        var command = new CreateAccomodationCommand(
            hostId.Value,
            title,
            street,
            postalCode,
            city,
            country,
            facilities,
            null,
            null
            );

        var handler = new CreateAccomodationHandler(mockAccomodationRepo.Object, mockImageStorage.Object) as ICreateAccomodationHandler;

        // Act
        await handler.HandleAsync(command);

        // Assert
        mockAccomodationRepo.Verify(r => r.CreateAsync(It.IsAny<Accomodation>()), Times.Once);
        mockAccomodationRepo.Verify(r => r.SaveAsync(),Times.Once);
    }
}
