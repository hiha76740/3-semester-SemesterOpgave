using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;

namespace EmailService.ApplicationLib.Handlers;

public class SendBookingConfirmationHandler(IEmailSenderService emailSender) : ISendBookingConfirmationHandler
{
    Task ISendBookingConfirmationHandler.HandleAsync(SendBookingConfirmationCommand command)
    {
        var subject = $"Bookingbekræftelse";
        var name = $"{command.UserFirstName} {command.UserLastName}";

        var body = $"""
            Hej {command.UserFirstName} {command.UserLastName}

            Tak for din booking.

            Ordrenummer: {command.BookingId}
            Periode: {command.StartDate} - {command.EndDate}

            INDSÆT BILLEDE HER fRA LINK

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
            """;
        
        return emailSender.SendAsync(
            name,
            command.UserEmail,
            subject,
            body
            );
    }
}
