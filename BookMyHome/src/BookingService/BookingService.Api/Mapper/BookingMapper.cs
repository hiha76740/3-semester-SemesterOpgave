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
                request.StartDate,
                request.EndDate,
                request.Price
                );

            return output;

        }
    }
}
