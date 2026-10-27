using BookMyHome.ContractsLib.Events;
using EmailService.FacadeLib.Commands.DTOs;

namespace EmailService.Api.Mappers
{
    public static class BookingEventMapper
    {
        public static SendBookingConfirmationCommand AsSendBookingConfirmationCommand(this BookingPlacedIntegrationEvent integrationEvent)
        {
            var output = new SendBookingConfirmationCommand(
                integrationEvent.BookingNumber,
                integrationEvent.StartDate,
                integrationEvent.EndDate,
                integrationEvent.Price,
                integrationEvent.ListingName,
                integrationEvent.DailyPrice,
                integrationEvent.HouseRules,
                integrationEvent.AccomodationType,
                integrationEvent.Street,
                integrationEvent.PostalCode,
                integrationEvent.City,
                integrationEvent.Country,
                integrationEvent.Facilities,
                integrationEvent.ImageUrl,
                integrationEvent.FirstName,
                integrationEvent.LastName,
                integrationEvent.Email
                );

            return output;
        }
    }
}
