using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests.Bookings;
using BookMyHome.ContractsLib.Responses.Bookings;

namespace BookingService.Api.Mapper
{
    public static class BookingMapper
    {
        public static BookingResponse AsResponse(this BookingDTO Dto)
        {
            var output = new BookingResponse(
                Dto.Id,
                Dto.GuestId,
                Dto.AccomodationId,
                Dto.StartDate,
                Dto.EndDate,
                Dto.Price
                );

            return output;
        }

        public static CreateBookingCommand CreateRequestAsCommand(this CreateBookingRequest request)
        {
            var output = new CreateBookingCommand(
                request.GuestId,
                request.AccomodationId,
                request.ListingId,
                request.StartDate,
                request.EndDate,
                request.Price
                );

            return output;

        }

        public static BookingSummaryResponse AsBookingSummaryResponse(this BookingSummaryDto dto)
        {
            var output = new BookingSummaryResponse(
                dto.BookingId,
                dto.ListingName,
                dto.ListingType,
                dto.City,
                dto.Country,
                dto.StartDate,
                dto.EndDate,
                dto.Price,
                dto.BookingStatus
                );

            return output;
        }
    }
}
