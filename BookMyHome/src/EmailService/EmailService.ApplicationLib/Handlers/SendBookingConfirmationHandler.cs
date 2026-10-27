using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text;
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

            StringBuilder builder = new StringBuilder();

            builder.Append($"<p>Hej {command.UserFirstName} {command.UserLastName}</p>");
            builder.Append("<br/>");
            builder.Append("<p>Tak for din booking.</p>");
            builder.Append("<br/>");
            builder.Append($"<p>Ordrenummer: {command.BookingId}</p>");
            builder.Append($"<p>Periode: {command.StartDate} - {command.EndDate}</p>");
            builder.Append("<br/>");
            builder.Append($"<img src=\"{command.ImageUrl}\" alt=\"Listing image\" width=\"600\" height=\"500\" style=\"vertical-align:middle\">");
            builder.Append("<br/>");
            builder.Append($"<h3>{command.ListingName}</h3>");
            builder.Append($"<h4>Type: {command.AccomodationType}</h4>");
            builder.Append("<br/>");
            builder.Append($"<p>Addressen er:</p>");
            builder.Append($"<p>{command.Street}, {command.PostalCode} {command.City}, {command.Country}<p/>");
            builder.Append("<br/>");
            builder.Append("<p>Der vil være følgende facilities til rådighed:<p>");
            builder.Append($"<ul>{facilitiesHtml}</ul>");
            builder.Append("<br/>");
            builder.Append($"<p>Der er følgende hus regler:</p>");
            builder.Append($"<p>{command.HouseRules}</p>");
            builder.Append("<br/>");
            builder.Append($"<p>Daglig pris: {command.DailyPrice:C}</p>");
            builder.Append($"<p>Total: {command.Price:C}</p>");
            builder.Append("<br/>");
            builder.Append("<p>Ønsker du at annullere bookingen kan dette gøres via din profil</p>");
            builder.Append("<br/>");
            builder.Append("<img src=\"{{LogoCid}}\" alt=\"BookMyHome\" width=\"200\">");

            var body = builder.ToString();

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
