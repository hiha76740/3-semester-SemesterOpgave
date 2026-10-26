using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;

namespace EmailService.ApplicationLib.Handlers;

public class SendBookingConfirmationHandler(IEmailSenderService emailSender, ILogger<SendBookingConfirmationHandler> logger) : ISendBookingConfirmationHandler
{
    Task ISendBookingConfirmationHandler.HandleAsync(SendBookingConfirmationCommand command)
    {
        try
        {
            logger.LogInformation("Starting to send booking confirmation to email: {userEmail}", command.UserEmail);

            var subject = $"Bookingbekræftelse";
            var name = $"{command.UserFirstName} {command.UserLastName}";

            var body = $"""
            Hej {command.UserFirstName} {command.UserLastName}

            Tak for din booking.

            Ordrenummer: {command.BookingId}
            Periode: {command.StartDate} - {command.EndDate}

            INDSÆT BILLEDE HER FRA LINK

            {command.ListingName}
            Type: {command.AccomodationType}

            Addressen er:
            {command.Street}, {command.PostalCode} {command.City}, {command.Country}
            
            Der vil være følgende facilities til rådighed:
            INDSÆT FACILITIES HER!!!!

            Der er følgende hus regler:
            {command.HouseRules}

            Daglig pris: {command.DailyPrice:C}
            Total: {command.Price:C}

            Ønsker du at annullere bookingen kan dette gøres via din profil
            """;

            logger.LogInformation("Sending booking confirmation to email: {userEmail}", command.UserEmail);

            var emailDto = new SendEmailDto(name, command.UserEmail, subject, body);

            return emailSender.SendAsync(emailDto);
        }
        catch (Exception ex)
        {
            logger.LogError("Exception error: {error}", ex.Message);

            if (ex.InnerException != null)
                logger.LogError("InnerException error: {error}", ex.InnerException.Message);

            throw;
        }
    }
}
