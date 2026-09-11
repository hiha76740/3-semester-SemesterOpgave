using BookingService.ApplicationLib.Handlers;
using BookingService.ApplicationLib.Repositories;
using BookingService.ApplicationLib.Services;
using BookingService.DomainLib.Entities;
using BookingService.DomainLib.ValueObjects;
using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Commands.Interfaces;
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
        var startDate = DateOnly.FromDateTime(DateTime.UtcNow);
        var endDate = startDate.AddDays(5);
        var price = 5000m;


        var mockGuestService = new Mock<IGuestService>();
        var mockAccomodationService = new Mock<IAccomodationService>();
        var mockBookingRepo = new Mock<IBookingRepository>();

        mockGuestService
            .Setup(s => s.GuestExistAsync(guestId))
            .ReturnsAsync(true);

        mockAccomodationService
            .Setup(s => s.AccomodationExistAsync(accomodationId))
            .ReturnsAsync(true);

        mockBookingRepo
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(new List<Booking>());


        var command = new CreateBookingCommand(
            guestId.Value,
            accomodationId.Value,
            startDate,
            endDate,
            price);

        var handler = new CreateBookingHandler(mockGuestService.Object, mockAccomodationService.Object, mockBookingRepo.Object) as ICreateBookingHandler;

        // Act
        await handler.Handle(command);

        // Assert
        mockBookingRepo.Verify(r => r.AddAsync(It.IsAny<Booking>()),Times.Once);
        mockBookingRepo.Verify(r => r.SaveAsync(), Times.Once);
    }
}
