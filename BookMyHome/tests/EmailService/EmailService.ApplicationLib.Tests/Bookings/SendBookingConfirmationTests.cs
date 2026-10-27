using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Handlers;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmailService.ApplicationLib.Tests.Bookings;

public class SendBookingConfirmationTests
{
    [Fact]
    public async Task Handle_GivenValidData_CallsSendEmail()
    {
        // Arrange
        var mockEmailSender = new Mock<IEmailSenderService>();
        var mockLogger = new Mock<ILogger<SendBookingConfirmationHandler>>();

        var command = new SendBookingConfirmationCommand(
            1,
            DateOnly.FromDateTime(DateTime.Today),
            DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
            100,
            "TestListingName",
            50,
            "TestHouseRules",
            "House",
            "Testvej 2",
            "1234",
            "Testby",
            "Denmark",
            Array.Empty<string>(),
            null,
            "TestFirstname",
            "TestLastname",
            "test@test.dk"
            );

        var handler = new SendBookingConfirmationHandler(mockEmailSender.Object, mockLogger.Object) as ISendBookingConfirmationHandler;

        // Act
        await handler.HandleAsync(command);

        // Assert
        mockEmailSender.Verify(s => s.SendAsync(It.IsAny<SendEmailDto>()),Times.Once);
    }
}
