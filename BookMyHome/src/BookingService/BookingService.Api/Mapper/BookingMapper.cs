using BookingService.FacadeLib.Commands.DTOs;
using BookingService.FacadeLib.Queries.DTOs;
using BookMyHome.ContractsLib.Requests;
using BookMyHome.ContractsLib.Responses.BookingService;

namespace BookingService.Api.Mapper
{
    public static class BookingMapper
    {
        public static BookingResponse AsResponse(this BookingDTO DTO)
        {
            var output = new BookingResponse(
                DTO.Id,
                DTO.GuestId,
                DTO.AccomodationId,
                DTO.StartDate,
                DTO.EndDate,
                DTO.Price
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
