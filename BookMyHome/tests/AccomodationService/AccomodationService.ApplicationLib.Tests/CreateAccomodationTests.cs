using AccomodationService.ApplicationLib.Handlers;
using AccomodationService.ApplicationLib.Repositories;
using AccomodationService.DomainLib.Entities;
using AccomodationService.DomainLib.ValueObjects;
using AccomodationService.FacadeLib.Commands.DTOs;
using AccomodationService.FacadeLib.Commands.Interfaces;
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

        var mockAccomodationRepo = new Mock<IAccomodationRepository>();

        var command = new CreateAccomodationCommand(
            hostId.Value,
            title,
            street,
            postalCode,
            city,
            country
            );

        var handler = new CreateAccomodationHandler(mockAccomodationRepo.Object) as ICreateAccomodationHandler;

        // Act
        await handler.Handle(command);

        // Assert
        mockAccomodationRepo.Verify(r => r.CreateAsync(It.IsAny<Accomodation>()), Times.Once);
        mockAccomodationRepo.Verify(r => r.SaveAsync(),Times.Once);
    }
}
