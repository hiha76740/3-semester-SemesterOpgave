using BookingService.ApplicationLib.Handlers;
using BookingService.ApplicationLib.Repositories;
using BookingService.ApplicationLib.Services;
using BookingService.ApplicationLib.UnitOfWork;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
using BookMyHome.BuildingBlocksLib.Messaging;
using BookMyHome.ContractsLib.Responses.Accomodations;
using BookMyHome.ContractsLib.Responses.Users;
using Microsoft.Extensions.Logging;
using Moq;

namespace BookingService.ApplicationLib.Tests;

public class CreateBookingTests
{
    [Fact]
    public async Task Handle_GivenValidData_CallsAddAndSave()
    {
        // Arrange
        var guestId = new GuestId(Guid.NewGuid());
        var accomodationId = new AccomodationId(Guid.NewGuid());
        var listingId = new ListingId(Guid.NewGuid());
        var startDate = DateOnly.FromDateTime(DateTime.UtcNow);
        var endDate = startDate.AddDays(5);
        var price = 5000m;

        var userEmailItem = new UserEmailItemResponse("Fornavn", "Efternavn", "Test@test.dk");
        var listingEmailItem = new ListingEmailItemResponse(
            "Listingnavn",
            1, 
            "Hus regler",
            "House",
            "Testvej 2",
            "1234",
            "By", 
            "DK",
            Array.Empty<string>(),
            null);


        var mockGuestService = new Mock<IGuestService>();
        var mockAccomodationService = new Mock<IAccomodationService>();
        var mockListingService = new Mock<IListingService>();
        var mockBookingRepo = new Mock<IBookingRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();
        var mockIntergrationEventPublisher = new Mock<IIntegrationEventPublisher>();
        var mockLogger = new Mock<ILogger<CreateBookingHandler>>();

        mockGuestService
            .Setup(s => s.GetGuestEmailItemAsync(guestId))
            .ReturnsAsync(userEmailItem);

        mockAccomodationService
            .Setup(s => s.AccomodationExistAsync(accomodationId))
            .ReturnsAsync(true);

        mockListingService
            .Setup(s => s.GetListingEmailItemAsync(listingId))
            .ReturnsAsync(listingEmailItem);

        mockBookingRepo
            .Setup(r => r.HasOverlapingBookingAsync(accomodationId, startDate, endDate))
            .ReturnsAsync(false);


        var command = new CreateBookingCommand(
            guestId.Value,
            accomodationId.Value,
            listingId.Value,
            startDate,
            endDate,
            price);

        var handler = new CreateBookingHandler(mockGuestService.Object, mockAccomodationService.Object,mockListingService.Object, mockBookingRepo.Object, mockUnitOfWork.Object, mockIntergrationEventPublisher.Object, mockLogger.Object) as ICreateBookingHandler;

        // Act
        await handler.HandleAsync(command);

        // Assert
        mockBookingRepo.Verify(r => r.CreateAsync(It.IsAny<Booking>()), Times.Once);
        mockBookingRepo.Verify(r => r.SaveAsync(), Times.Once);
    }
}
