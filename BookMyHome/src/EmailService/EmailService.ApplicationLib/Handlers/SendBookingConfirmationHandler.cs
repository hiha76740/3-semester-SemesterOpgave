using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;

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

            string facilitiesHtml;

            if (command.Facilities != null &&
                command.Facilities.Length > 0)
            {
                var listItems = command.Facilities.Select(f => $"<li>{HtmlEncoder.Default.Encode(f)}</li>");

                facilitiesHtml = string.Join(Environment.NewLine, listItems);
            }
            else
            {
                facilitiesHtml = "<li>Ingen faciliteter angivet.</li>";
            }

            var body = $"""
            <p>Hej {command.UserFirstName} {command.UserLastName}</p>
            
            <p>Tak for din booking.</p>
            
            <p>Ordrenummer: {command.BookingId}</p>
            <p>Periode: {command.StartDate} - {command.EndDate}</p>
            
            <img src="{command.ImageUrl}" alt="Listing image" width="600" height="500" style="vertical-align:middle">
            
            <h3>{command.ListingName}</h3>
            <h4>Type: {command.AccomodationType}</h4>
            
            <p>Addressen er:</p>
            <p>{command.Street}, {command.PostalCode} {command.City}, {command.Country}<p/>
            
            <p>Der vil være følgende facilities til rådighed:<p>
            <ul>
                {facilitiesHtml}
            </ul>
            <br/>
            <p>Der er følgende hus regler:</p>
            <p>{command.HouseRules}</p>

            <p>Daglig pris: {command.DailyPrice:C}</p>
            <p>Total: {command.Price:C}</p>
            
            <p>Ønsker du at annullere bookingen kan dette gøres via din profil</p>
            """;

            logger.LogInformation("Sending booking confirmation to email: {userEmail}", command.UserEmail);

            var emailDto = new SendEmailDto(name, command.UserEmail, subject, body, "html");

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
