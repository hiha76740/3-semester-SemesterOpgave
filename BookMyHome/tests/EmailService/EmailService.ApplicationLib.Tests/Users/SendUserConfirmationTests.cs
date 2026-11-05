using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Handlers;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;

namespace EmailService.ApplicationLib.Tests.Users
{
    public class SendUserConfirmationTests
    {
        [Fact]
        public async Task Handle_GivenValidData_CallsSendEmail()
        {
            // Arrange
            var mockEmailSender = new Mock<IEmailSenderService>();
            var mockLogger = new Mock<ILogger<SendUserConfirmationHandler>>();

            var command = new SendUserConfirmationCommand(
                "testfirstname", 
                "testlastname", 
                "test@test.dk",
                "testusername"
                );

            var handler = new SendUserConfirmationHandler(mockEmailSender.Object,mockLogger.Object) as ISendUserConfirmationHandler;

            // Act
            await handler.HandleAsync(command);

            // Assert
            mockEmailSender.Verify(s => s.SendAsync(It.IsAny<SendEmailDto>()), Times.Once);
        }
    }
}
