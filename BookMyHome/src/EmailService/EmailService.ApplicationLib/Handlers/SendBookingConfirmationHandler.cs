using EmailService.ApplicationLib.Dtos;
using EmailService.ApplicationLib.Services;
using EmailService.FacadeLib.Commands.DTOs;
using EmailService.FacadeLib.Commands.Interfaces;
using Microsoft.Extensions.Logging;
using System.Globalization;
using System.Text;
using System.Text.Encodings.Web;

namespace EmailService.ApplicationLib.Handlers;

///
public class SendBookingConfirmationHandler(IEmailSenderService emailSender, ILogger<SendBookingConfirmationHandler> logger) : ISendBookingConfirmationHandler
{
    Task ISendBookingConfirmationHandler.HandleAsync(SendBookingConfirmationCommand command)
    {
        try
        {
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Starting to send booking confirmation to email: {UserEmail}", command.UserEmail);

            var startDateFormatted = command.StartDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            var endDateFormatted = command.EndDate.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

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

            var builder = new StringBuilder();

            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<p>Hej {command.UserFirstName} {command.UserLastName}</p>");
            builder.Append("<br/>");
            builder.Append("<p>Tak for din booking.</p>");
            builder.Append("<br/>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<p>Bookingnummer: {command.BookingNumber}</p>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<p>Periode: {startDateFormatted} - {endDateFormatted}</p>");
            builder.Append("<br/>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<img src=\"{command.ImageUrl}\" alt=\"Listing image\" width=\"600\" height=\"500\" style=\"vertical-align:middle\">");
            builder.Append("<br/>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<h3>{command.ListingName}</h3>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<h4>Type: {command.AccomodationType}</h4>");
            builder.Append("<br/>");
            builder.Append($"<p>Addressen er:</p>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<p>{command.Street}, {command.PostalCode} {command.City}, {command.Country}<p/>");
            builder.Append("<br/>");
            builder.Append("<p>Der vil være følgende facilities til rådighed:<p>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<ul>{facilitiesHtml}</ul>");
            builder.Append("<br/>");
            builder.Append($"<p>Der er følgende hus regler:</p>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<p>{command.HouseRules}</p>");
            builder.Append("<br/>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<p>Daglig pris: {command.DailyPrice:2}DKK</p>");
            builder.Append(CultureInfo.GetCultureInfo("da-DK"), $"<p>Total: {command.Price:2}</p>");
            builder.Append("<br/>");
            builder.Append("<p>Ønsker du at annullere bookingen kan dette gøres via din profil</p>");
            builder.Append("<br/>");
            builder.Append("<img src=\"{{LogoCid}}\" alt=\"BookMyHome\" width=\"200\">");

            var body = builder.ToString();

            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Sending booking confirmation to email: {UserEmail}", command.UserEmail);

            var emailDto = new SendEmailDto(name, command.UserEmail, subject, body);

            return emailSender.SendAsync(emailDto);
        }
        catch (Exception ex)
        {
            if (logger.IsEnabled(LogLevel.Error))
            {
                logger.LogError("Exception error: {Error}", ex.Message);

                if (ex.InnerException != null)
                    logger.LogError("InnerException error: {Error}", ex.InnerException.Message);
            }
            throw;
        }
    }
}
